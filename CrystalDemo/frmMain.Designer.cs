namespace Crystal
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeProject = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOriginal = new FastColoredTextBoxNS.FastColoredTextBox();
            this.txtNew = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewSIze = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOriginalSize = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newProjectToolStripMenuItem.Text = "New Project...";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveToolStripMenuItem.Text = "Save Project";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveAsToolStripMenuItem.Text = "Save Project as...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeProject);
            this.groupBox1.Location = new System.Drawing.Point(7, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 212);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Explorer";
            // 
            // treeProject
            // 
            this.treeProject.Location = new System.Drawing.Point(6, 19);
            this.treeProject.Name = "treeProject";
            this.treeProject.Size = new System.Drawing.Size(188, 185);
            this.treeProject.TabIndex = 1;
            this.treeProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeProject_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(7, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 257);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOriginal);
            this.groupBox3.Controls.Add(this.txtNew);
            this.groupBox3.Location = new System.Drawing.Point(213, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 347);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Text";
            // 
            // txtOriginal
            // 
            this.txtOriginal.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtOriginal.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.txtOriginal.BackBrush = null;
            this.txtOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtOriginal.CharHeight = 14;
            this.txtOriginal.CharWidth = 8;
            this.txtOriginal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOriginal.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtOriginal.IsReplaceMode = false;
            this.txtOriginal.Location = new System.Drawing.Point(7, 19);
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Paddings = new System.Windows.Forms.Padding(0);
            this.txtOriginal.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtOriginal.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtOriginal.ServiceColors")));
            this.txtOriginal.Size = new System.Drawing.Size(487, 158);
            this.txtOriginal.TabIndex = 4;
            this.txtOriginal.WordWrap = true;
            this.txtOriginal.Zoom = 100;
            this.txtOriginal.TextChanging += new System.EventHandler<FastColoredTextBoxNS.TextChangingEventArgs>(this.txtOriginal_TextChanging);
            this.txtOriginal.Load += new System.EventHandler(this.txtOriginal_Load);
            this.txtOriginal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOriginal_KeyUp);
            this.txtOriginal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtOriginal_MouseMove);
            this.txtOriginal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtOriginal_MouseUp);
            // 
            // txtNew
            // 
            this.txtNew.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtNew.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.txtNew.BackBrush = null;
            this.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtNew.CharHeight = 14;
            this.txtNew.CharWidth = 8;
            this.txtNew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNew.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtNew.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtNew.IsReplaceMode = false;
            this.txtNew.Location = new System.Drawing.Point(7, 183);
            this.txtNew.Name = "txtNew";
            this.txtNew.Paddings = new System.Windows.Forms.Padding(0);
            this.txtNew.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtNew.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtNew.ServiceColors")));
            this.txtNew.Size = new System.Drawing.Size(487, 158);
            this.txtNew.TabIndex = 3;
            this.txtNew.WordWrap = true;
            this.txtNew.Zoom = 100;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnImport);
            this.groupBox4.Location = new System.Drawing.Point(213, 380);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(500, 122);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Actions";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(6, 19);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(82, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import Text";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtLength);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtNewSIze);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtOriginalSize);
            this.groupBox5.Location = new System.Drawing.Point(719, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 475);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Length";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(75, 19);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(141, 20);
            this.txtLength.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "New Size";
            // 
            // txtNewSIze
            // 
            this.txtNewSIze.Location = new System.Drawing.Point(75, 71);
            this.txtNewSIze.Name = "txtNewSIze";
            this.txtNewSIze.Size = new System.Drawing.Size(141, 20);
            this.txtNewSIze.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Original Size";
            // 
            // txtOriginalSize
            // 
            this.txtOriginalSize.Location = new System.Drawing.Point(75, 45);
            this.txtOriginalSize.Name = "txtOriginalSize";
            this.txtOriginalSize.Size = new System.Drawing.Size(141, 20);
            this.txtOriginalSize.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 507);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Crystal Demo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeProject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewSIze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOriginalSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLength;
        private FastColoredTextBoxNS.FastColoredTextBox txtOriginal;
        private FastColoredTextBoxNS.FastColoredTextBox txtNew;
    }
}

