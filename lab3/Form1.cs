using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace lab3
{
    public partial class Form1 : Form
    {

        const string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FSPDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }
        
        private int FindIndexToAdd(TreeNodeCollection nodes, TreeNode newNode)
        {
            int index = 0;

            foreach (TreeNode node in nodes)
            {
                if (string.Compare(node.Text, newNode.Text, StringComparison.CurrentCulture) > 0)
                {
                    break;
                }
                index++;
            }
            return index;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                treeView1.Nodes.Clear();
                
                cn.Open();
                var sql = "select * from StudyGroups";
                var cmd = new SqlCommand(sql, cn);
                Focus();
                treeView1.Focus();
                treeView1.SelectedNode = null;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TreeNode n = new TreeNode(dr["GroupName"].ToString(), 0,0);
                        treeView1.Nodes.Add(n);
                        //LoadStudent((int)dr["GroupID"],n);
                        n.Nodes.Add(new TreeNode());
                        n.ContextMenuStrip = contextMenuStripGroups;
                        n.Tag = (int)dr["GroupID"];
                    }
                }
               

                button1.Text = "Обновить";
                ContextMenuStrip = contextMenuStripMain;
            }
        }

        void LoadStudent(int groupID, TreeNode parent)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var sql = @"select TRIM(LastName) +' '+ TRIM(FirstName) + ' ' + TRIM(MiddleName) as ""ФИО"" ,  TRIM(CodeforcesNickname) as CFN, StudentID
	from Students where Students.GroupID = @groupID;";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("groupID", groupID);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TreeNode n = new TreeNode(dr["ФИО"].ToString() + " (" + dr["CFN"].ToString() + ')', 1 ,1 );
                        parent.Nodes.Add(n);
                        LoadTeam((int)dr["StudentID"], n);
                        n.ContextMenuStrip = contextMenuStripStudents;
                        n.Tag = (int)dr["StudentID"];
                    }
                }
            }
        }

        void LoadTeam(int studentID, TreeNode parent)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var sql = @"select TRIM(TeamName)  as TeamName, Teams.TeamID, ParticipantID  from Participants left join Teams ON Teams.TeamID = Participants.TeamID 
left join  Students on Students.StudentID = Participants.StudentID where Students.StudentID = @studentID and TeamName is not null
order by TeamName asc";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("studentID", studentID);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TreeNode n = new TreeNode(dr["TeamName"].ToString(), 2, 2);
                        parent.Nodes.Add(n);
                        n.ContextMenuStrip = contextMenuStripTeams;
                        int[] ar = { (int)dr["ParticipantID"], (int)dr["TeamID"] };
                        n.Tag = ar;
                    }
                }
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = treeView1.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    treeView1.SelectedNode = node;
                }
            }
        }

        #region GROUPS CRUDE

        private void добавитьГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addGroup = new AddGroup();
            if (addGroup.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    var sql = @"INSERT INTO [dbo].[StudyGroups]
                             ([GroupName])
                             OUTPUT INSERTED.GroupID
                            VALUES
                            (@newGroupName);";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@newGroupName", addGroup.newNameGroup);
                   
                    try
                    {
                        int insertedId = (int)cmd.ExecuteScalar();
                        TreeNode n = new TreeNode(addGroup.newNameGroup, 0, 0);
                        int index = FindIndexToAdd(treeView1.Nodes, n);
                        treeView1.Nodes.Insert(index, n);
                        n.ContextMenuStrip = contextMenuStripGroups;
                        n.Tag = insertedId;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show($"Ошибка! Группа с названием {addGroup.newNameGroup} уже есть в БД!");
                    }          
                }
            }
        }

        private void удалитьГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var sql = @"delete from StudyGroups where GroupID = @groupID;";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@groupID", treeView1.SelectedNode.Tag);
                try
                {
                    cmd.ExecuteNonQuery();
                    treeView1.SelectedNode.Remove();
                }
                catch (SqlException)
                {
                    MessageBox.Show($"Ошибка!");
                }
            }
        }

        private void изменитьГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addGroup = new AddGroup();
            if (addGroup.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    var sql = @"UPDATE [dbo].[StudyGroups]
                        SET [GroupName] = @newGroupName
                        WHERE [GroupID] = @groupID;";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@newGroupName", addGroup.newNameGroup);
                    cmd.Parameters.AddWithValue("@groupID", treeView1.SelectedNode.Tag);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        treeView1.SelectedNode.Text = addGroup.newNameGroup;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show($"Ошибка! Группа с названием {addGroup.newNameGroup} уже есть в БД!");
                    }
                }
            }
        }
        #endregion GROUPS CRUDE
        #region STUDENTS CRUDE
        private void добавитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addStudent = new AddStudent();
            if (addStudent.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    var sql = @"INSERT INTO [dbo].[Students]
                           ([LastName]
                           ,[FirstName]
                           ,[MiddleName]
                           ,[CodeforcesNickname]
                           ,[GroupID])
                    OUTPUT INSERTED.StudentID
                     VALUES
                           ( @lastName
                           ,@firstName
                           ,@middleName
                           ,@codeforcesNickname
                           ,@groupID);";
                    var cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@lastName", addStudent.LastName );
                    cmd.Parameters.AddWithValue("@firstName", addStudent.FirstName);
                    cmd.Parameters.AddWithValue("@middleName", addStudent.MiddleName);
                    cmd.Parameters.AddWithValue("@codeforcesNickname", addStudent.CodeforcesNickname);
                    cmd.Parameters.AddWithValue("@groupID", treeView1.SelectedNode.Tag);

                    try
                    {
                        int insertedId = (int)cmd.ExecuteScalar();
                        TreeNode n = new TreeNode(addStudent.LastName +' '+ addStudent.FirstName + ' '+ addStudent.MiddleName + " (" + addStudent.CodeforcesNickname + ')', 1, 1);
                        int index = FindIndexToAdd(treeView1.SelectedNode.Nodes, n);
                        treeView1.SelectedNode.Nodes.Insert(index, n);
                        n.ContextMenuStrip = contextMenuStripStudents;                   
                        n.Tag = insertedId;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show($"Ошибка! Студент с ником {addStudent.CodeforcesNickname} уже есть в БД!");
                    }
                }
            }
        }

        private void удалитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var sql = @"delete from Students where StudentID = @studentID;";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@studentID", treeView1.SelectedNode.Tag);
               
                try
                {
                    cmd.ExecuteNonQuery();
                    treeView1.SelectedNode.Remove();
                }
                catch (SqlException)
                {
                    MessageBox.Show($"Ошибка!");
                }
            }
        }
     
        private void изменитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addStudent = new AddStudent();
            if (addStudent.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    var sql = @"UPDATE [dbo].[Students]
                           SET [LastName] = @lastName
                              ,[FirstName] = @FirstName
                              ,[MiddleName] = @MiddleName
                              ,[CodeforcesNickname] = @CodeforcesNickname
                         WHERE  [StudentID] = @studentID; ";
                    var cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@lastName", addStudent.LastName);
                    cmd.Parameters.AddWithValue("@firstName", addStudent.FirstName);
                    cmd.Parameters.AddWithValue("@middleName", addStudent.MiddleName);
                    cmd.Parameters.AddWithValue("@codeforcesNickname", addStudent.CodeforcesNickname);
                    cmd.Parameters.AddWithValue("@studentID", treeView1.SelectedNode.Tag);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        treeView1.SelectedNode.Text = addStudent.LastName + ' ' + addStudent.FirstName + ' ' + addStudent.MiddleName + " (" + addStudent.CodeforcesNickname + ')';
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show($"Ошибка! Студент с ником {addStudent.CodeforcesNickname} уже есть в БД!");
                    }
                }
            }
        }
        #endregion STUDENTS CRUDE
        #region TEAMS CRUDE
        private void добавитьКомандуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addTeam = new AddTeam();
            if (addTeam.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    var sql = @"
                           DECLARE @teamID INT

                            IF EXISTS (SELECT * FROM Teams WHERE TeamName = @newTeamName)
                            BEGIN
                                SET @teamID = (SELECT TeamID FROM Teams WHERE TeamName = @newTeamName)
                            END
                            ELSE
                            BEGIN
                                INSERT INTO Teams (TeamName)
                                VALUES (@newTeamName)
    
                                SET @teamID = SCOPE_IDENTITY()
                            END

                            IF EXISTS (SELECT * FROM Participants WHERE StudentID = @curStudentId AND TeamID = @teamID)
                            BEGIN
                                RAISERROR('Связь между командой и студентом уже существует',16,1)
                            END
                            ELSE
                            BEGIN
                                INSERT INTO Participants (StudentID, TeamID)
                                OUTPUT inserted.ParticipantID, @teamId
                                VALUES (@curStudentId, @teamID)
                            END
";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@newTeamName", addTeam.teamName);
                    cmd.Parameters.AddWithValue("@curStudentId", treeView1.SelectedNode.Tag);

                    try
                    {
                        var reader = cmd.ExecuteReader();
                        int partid = 1,  teamid = 1;
                        while (reader.Read())
                        {
                            partid = reader.GetInt32(0);
                            teamid = reader.GetInt32(1);
                        }
                        int[] ar = { partid , teamid };

                        TreeNode n = new TreeNode(addTeam.teamName, 2, 2);
                        int index = FindIndexToAdd(treeView1.SelectedNode.Nodes, n);
                        treeView1.SelectedNode.Nodes.Insert(index, n);
                        n.ContextMenuStrip = contextMenuStripTeams;
                        n.Tag = ar;
                    }
                        catch (SqlException)
                    {
                        MessageBox.Show($"Ошибка! У студента уже есть команда {addTeam.teamName}!");
                    }
                 }
            }
        }

        private void изменитьКомандуToolStripMenuItem_Click(object sender, EventArgs e)
        {
             var addTeam = new AddTeam();
            if (addTeam.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    var sql = @"DECLARE @studentID INT
                            SELECT @studentID = StudentID FROM Participants WHERE ParticipantID = @participantID

                            IF NOT EXISTS (SELECT * FROM Teams WHERE TeamName = @newTeamName)
                            BEGIN
                                INSERT INTO Teams (TeamName) VALUES (@newTeamName)
                                DECLARE @newTeamID INT
                                SET @newTeamID = SCOPE_IDENTITY()

	                            UPDATE Participants
	                            SET TeamID = @newTeamID
	                            WHERE ParticipantID = @participantID


                                SELECT SCOPE_IDENTITY() AS ParticipantID, @newTeamID AS TeamID 
                            END
                            ELSE
                            BEGIN
 
                                IF EXISTS (SELECT * FROM Participants p JOIN Teams t ON p.TeamID = t.TeamID WHERE p.StudentID = @studentID AND t.TeamName = @newTeamName)
                                BEGIN
                                    RAISERROR('Связь между командой и студентом уже существует', 16, 1)
                                END
                                ELSE
	                            BEGIN
                                    UPDATE Participants SET TeamID = t.TeamID FROM Participants p JOIN Teams t ON t.TeamName = @newTeamName WHERE p.ParticipantID = @participantID

                                    SELECT @participantID AS ParticipantID, TeamID 
                                    FROM Participants 
                                    WHERE ParticipantID = @participantID
                                END
                            END";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@participantID", ((int[])treeView1.SelectedNode.Tag)[0]);
                    cmd.Parameters.AddWithValue("@newTeamName", addTeam.teamName);
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        int partid = 1, teamid = 1;
                        while (reader.Read())
                        {
                            partid = reader.GetInt32(0);
                            teamid = reader.GetInt32(1);
                        }
                        int[] ar = { partid, teamid };
                        treeView1.SelectedNode.Tag = ar;
                        treeView1.SelectedNode.Text = addTeam.teamName;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show($"Ошибка! У студента уже есть команда {addTeam.teamName}!");
                    }
                }
            }
        }

        private void удалитьКомандуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var sql = @"DELETE FROM Participants
                            WHERE ParticipantID = @participantID;";
                var cmd = new SqlCommand(sql, cn);
                
                cmd.Parameters.AddWithValue("@participantID", ((int[])treeView1.SelectedNode.Tag)[0]);
                try
                {
                    cmd.ExecuteNonQuery();
                    treeView1.SelectedNode.Remove();
                }
                catch (SqlException)
                {
                    MessageBox.Show($"Ошибка!");
                }
            }
        }
        #endregion TEAMS CRUDE

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

            if (e.Node.IsExpanded)
                return;

            if (e.Node.Level == 0)
                {
                if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
                {
                    e.Node.Nodes.Clear();
                    LoadStudent((int)e.Node.Tag, e.Node);
                }
                }
           else if (e.Node.Level == 1)
                {
                if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
                {
                    e.Node.Nodes.Clear();
                    LoadTeam((int)e.Node.Tag, e.Node);
                }
            }
            
        }
    }
}
