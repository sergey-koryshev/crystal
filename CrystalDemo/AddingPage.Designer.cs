namespace Crystal

{
    partial class AddingPage
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
            this.lblNamePage = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtOriginalTablePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewTablePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddOriginalTable = new System.Windows.Forms.Button();
            this.btnNewTablePath = new System.Windows.Forms.Button();
            this.btnAddPluginTable = new System.Windows.Forms.Button();
            this.txtTablePlugin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddStoreMethodPlugins = new System.Windows.Forms.Button();
            this.txtStoreMethodPlugin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxIsLinked = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.openTable = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblNamePage
            // 
            this.lblNamePage.AutoSize = true;
            this.lblNamePage.Location = new System.Drawing.Point(6, 10);
            this.lblNamePage.Name = "lblNamePage";
            this.lblNamePage.Size = new System.Drawing.Size(35, 13);
            this.lblNamePage.TabIndex = 0;
            this.lblNamePage.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(47, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(189, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtOriginalTablePath
            // 
            this.txtOriginalTablePath.Location = new System.Drawing.Point(84, 33);
            this.txtOriginalTablePath.Name = "txtOriginalTablePath";
            this.txtOriginalTablePath.Size = new System.Drawing.Size(120, 20);
            this.txtOriginalTablePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Table";
            // 
            // txtNewTablePath
            // 
            this.txtNewTablePath.Location = new System.Drawing.Point(71, 59);
            this.txtNewTablePath.Name = "txtNewTablePath";
            this.txtNewTablePath.Size = new System.Drawing.Size(133, 20);
            this.txtNewTablePath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Table";
            // 
            // btnAddOriginalTable
            // 
            this.btnAddOriginalTable.Location = new System.Drawing.Point(211, 33);
            this.btnAddOriginalTable.Name = "btnAddOriginalTable";
            this.btnAddOriginalTable.Size = new System.Drawing.Size(25, 20);
            this.btnAddOriginalTable.TabIndex = 6;
            this.btnAddOriginalTable.Text = "...";
            this.btnAddOriginalTable.UseVisualStyleBackColor = true;
            this.btnAddOriginalTable.Click += new System.EventHandler(this.btnAddOriginalTable_Click);
            // 
            // btnNewTablePath
            // 
            this.btnNewTablePath.Location = new System.Drawing.Point(211, 59);
            this.btnNewTablePath.Name = "btnNewTablePath";
            this.btnNewTablePath.Size = new System.Drawing.Size(25, 20);
            this.btnNewTablePath.TabIndex = 7;
            this.btnNewTablePath.Text = "...";
            this.btnNewTablePath.UseVisualStyleBackColor = true;
            this.btnNewTablePath.Click += new System.EventHandler(this.btnNewTablePath_Click);
            // 
            // btnAddPluginTable
            // 
            this.btnAddPluginTable.Location = new System.Drawing.Point(211, 85);
            this.btnAddPluginTable.Name = "btnAddPluginTable";
            this.btnAddPluginTable.Size = new System.Drawing.Size(25, 20);
            this.btnAddPluginTable.TabIndex = 10;
            this.btnAddPluginTable.Text = "...";
            this.btnAddPluginTable.UseVisualStyleBackColor = true;
            this.btnAddPluginTable.Click += new System.EventHandler(this.btnAddPluginTable_Click);
            // 
            // txtTablePlugin
            // 
            this.txtTablePlugin.Location = new System.Drawing.Point(78, 85);
            this.txtTablePlugin.Name = "txtTablePlugin";
            this.txtTablePlugin.Size = new System.Drawing.Size(126, 20);
            this.txtTablePlugin.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Table Plugin";
            // 
            // btnAddStoreMethodPlugins
            // 
            this.btnAddStoreMethodPlugins.Location = new System.Drawing.Point(211, 111);
            this.btnAddStoreMethodPlugins.Name = "btnAddStoreMethodPlugins";
            this.btnAddStoreMethodPlugins.Size = new System.Drawing.Size(25, 20);
            this.btnAddStoreMethodPlugins.TabIndex = 13;
            this.btnAddStoreMethodPlugins.Text = "...";
            this.btnAddStoreMethodPlugins.UseVisualStyleBackColor = true;
            this.btnAddStoreMethodPlugins.Click += new System.EventHandler(this.btnAddStoreMethodPlugins_Click);
            // 
            // txtStoreMethodPlugin
            // 
            this.txtStoreMethodPlugin.Location = new System.Drawing.Point(83, 111);
            this.txtStoreMethodPlugin.Name = "txtStoreMethodPlugin";
            this.txtStoreMethodPlugin.Size = new System.Drawing.Size(121, 20);
            this.txtStoreMethodPlugin.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Store Method";
            // 
            // cbxIsLinked
            // 
            this.cbxIsLinked.AutoSize = true;
            this.cbxIsLinked.Location = new System.Drawing.Point(9, 137);
            this.cbxIsLinked.Name = "cbxIsLinked";
            this.cbxIsLinked.Size = new System.Drawing.Size(75, 17);
            this.cbxIsLinked.TabIndex = 14;
            this.cbxIsLinked.Text = "Is Linked?";
            this.cbxIsLinked.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(9, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(161, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // openTable
            // 
            this.openTable.FileName = "openFileDialog1";
            // 
            // AddingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 191);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbxIsLinked);
            this.Controls.Add(this.btnAddStoreMethodPlugins);
            this.Controls.Add(this.txtStoreMethodPlugin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddPluginTable);
            this.Controls.Add(this.txtTablePlugin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNewTablePath);
            this.Controls.Add(this.btnAddOriginalTable);
            this.Controls.Add(this.txtNewTablePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOriginalTablePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblNamePage);
            this.Name = "AddingPage";
            this.Text = "AddingPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNamePage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtOriginalTablePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewTablePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddOriginalTable;
        private System.Windows.Forms.Button btnNewTablePath;
        private System.Windows.Forms.Button btnAddPluginTable;
        private System.Windows.Forms.TextBox txtTablePlugin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddStoreMethodPlugins;
        private System.Windows.Forms.TextBox txtStoreMethodPlugin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxIsLinked;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog openTable;
    }
}