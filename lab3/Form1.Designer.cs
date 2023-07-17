namespace lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStripGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьСтудентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьГруппуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьГруппуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripStudents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьКомандуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьСтудентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСтудентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTeams = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьКомандуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьКомандуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьГруппуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripGroups.SuspendLayout();
            this.contextMenuStripStudents.SuspendLayout();
            this.contextMenuStripTeams.SuspendLayout();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(546, 355);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "multiple-users-silhouette.png");
            this.imageList1.Images.SetKeyName(1, "user.png");
            this.imageList1.Images.SetKeyName(2, "id-card.png");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStripGroups
            // 
            this.contextMenuStripGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСтудентаToolStripMenuItem,
            this.изменитьГруппуToolStripMenuItem,
            this.удалитьГруппуToolStripMenuItem});
            this.contextMenuStripGroups.Name = "contextMenuStripGroups";
            this.contextMenuStripGroups.Size = new System.Drawing.Size(209, 76);
            // 
            // добавитьСтудентаToolStripMenuItem
            // 
            this.добавитьСтудентаToolStripMenuItem.Name = "добавитьСтудентаToolStripMenuItem";
            this.добавитьСтудентаToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.добавитьСтудентаToolStripMenuItem.Text = "Добавить студента";
            this.добавитьСтудентаToolStripMenuItem.Click += new System.EventHandler(this.добавитьСтудентаToolStripMenuItem_Click);
            // 
            // изменитьГруппуToolStripMenuItem
            // 
            this.изменитьГруппуToolStripMenuItem.Name = "изменитьГруппуToolStripMenuItem";
            this.изменитьГруппуToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.изменитьГруппуToolStripMenuItem.Text = "Изменить группу";
            this.изменитьГруппуToolStripMenuItem.Click += new System.EventHandler(this.изменитьГруппуToolStripMenuItem_Click);
            // 
            // удалитьГруппуToolStripMenuItem
            // 
            this.удалитьГруппуToolStripMenuItem.Name = "удалитьГруппуToolStripMenuItem";
            this.удалитьГруппуToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.удалитьГруппуToolStripMenuItem.Text = "Удалить группу";
            this.удалитьГруппуToolStripMenuItem.Click += new System.EventHandler(this.удалитьГруппуToolStripMenuItem_Click);
            // 
            // contextMenuStripStudents
            // 
            this.contextMenuStripStudents.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripStudents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКомандуToolStripMenuItem,
            this.изменитьСтудентаToolStripMenuItem,
            this.удалитьСтудентаToolStripMenuItem});
            this.contextMenuStripStudents.Name = "contextMenuStripStudents";
            this.contextMenuStripStudents.Size = new System.Drawing.Size(211, 76);
            // 
            // добавитьКомандуToolStripMenuItem
            // 
            this.добавитьКомандуToolStripMenuItem.Name = "добавитьКомандуToolStripMenuItem";
            this.добавитьКомандуToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.добавитьКомандуToolStripMenuItem.Text = "Добавить команду";
            this.добавитьКомандуToolStripMenuItem.Click += new System.EventHandler(this.добавитьКомандуToolStripMenuItem_Click);
            // 
            // изменитьСтудентаToolStripMenuItem
            // 
            this.изменитьСтудентаToolStripMenuItem.Name = "изменитьСтудентаToolStripMenuItem";
            this.изменитьСтудентаToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.изменитьСтудентаToolStripMenuItem.Text = "Изменить студента";
            this.изменитьСтудентаToolStripMenuItem.Click += new System.EventHandler(this.изменитьСтудентаToolStripMenuItem_Click);
            // 
            // удалитьСтудентаToolStripMenuItem
            // 
            this.удалитьСтудентаToolStripMenuItem.Name = "удалитьСтудентаToolStripMenuItem";
            this.удалитьСтудентаToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.удалитьСтудентаToolStripMenuItem.Text = "Удалить студента";
            this.удалитьСтудентаToolStripMenuItem.Click += new System.EventHandler(this.удалитьСтудентаToolStripMenuItem_Click);
            // 
            // contextMenuStripTeams
            // 
            this.contextMenuStripTeams.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTeams.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьКомандуToolStripMenuItem,
            this.удалитьКомандуToolStripMenuItem});
            this.contextMenuStripTeams.Name = "contextMenuStripTeams";
            this.contextMenuStripTeams.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripTeams.Size = new System.Drawing.Size(211, 52);
            // 
            // изменитьКомандуToolStripMenuItem
            // 
            this.изменитьКомандуToolStripMenuItem.Name = "изменитьКомандуToolStripMenuItem";
            this.изменитьКомандуToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.изменитьКомандуToolStripMenuItem.Text = "Изменить команду";
            this.изменитьКомандуToolStripMenuItem.Click += new System.EventHandler(this.изменитьКомандуToolStripMenuItem_Click);
            // 
            // удалитьКомандуToolStripMenuItem
            // 
            this.удалитьКомандуToolStripMenuItem.Name = "удалитьКомандуToolStripMenuItem";
            this.удалитьКомандуToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.удалитьКомандуToolStripMenuItem.Text = "Удалить команду";
            this.удалитьКомандуToolStripMenuItem.Click += new System.EventHandler(this.удалитьКомандуToolStripMenuItem_Click);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьГруппуToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(197, 28);
            // 
            // добавитьГруппуToolStripMenuItem
            // 
            this.добавитьГруппуToolStripMenuItem.Name = "добавитьГруппуToolStripMenuItem";
            this.добавитьГруппуToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.добавитьГруппуToolStripMenuItem.Text = "Добавить группу";
            this.добавитьГруппуToolStripMenuItem.Click += new System.EventHandler(this.добавитьГруппуToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 417);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Lab3";
            this.contextMenuStripGroups.ResumeLayout(false);
            this.contextMenuStripStudents.ResumeLayout(false);
            this.contextMenuStripTeams.ResumeLayout(false);
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroups;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтудентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьГруппуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьГруппуToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStudents;
        private System.Windows.Forms.ToolStripMenuItem добавитьКомандуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьСтудентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтудентаToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTeams;
        private System.Windows.Forms.ToolStripMenuItem изменитьКомандуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьКомандуToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem добавитьГруппуToolStripMenuItem;
    }
}

