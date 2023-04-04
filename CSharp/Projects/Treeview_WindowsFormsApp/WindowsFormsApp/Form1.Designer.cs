namespace WindowsFormsApp
{
    partial class TreeViewForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.NodeTextBox = new System.Windows.Forms.TextBox();
            this.ChildNodeComboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddChildButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 85);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(295, 266);
            this.treeView.TabIndex = 0;
            // 
            // NodeTextBox
            // 
            this.NodeTextBox.Location = new System.Drawing.Point(12, 15);
            this.NodeTextBox.Name = "NodeTextBox";
            this.NodeTextBox.Size = new System.Drawing.Size(121, 20);
            this.NodeTextBox.TabIndex = 1;
            // 
            // ChildNodeComboBox
            // 
            this.ChildNodeComboBox.FormattingEnabled = true;
            this.ChildNodeComboBox.Items.AddRange(new object[] {
            "SubNode1",
            "SubNode2",
            "SubNode3",
            "SubNode4",
            "SubNode5",
            "SubNode6"});
            this.ChildNodeComboBox.Location = new System.Drawing.Point(12, 41);
            this.ChildNodeComboBox.Name = "ChildNodeComboBox";
            this.ChildNodeComboBox.Size = new System.Drawing.Size(121, 21);
            this.ChildNodeComboBox.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(186, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(121, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddChildButton
            // 
            this.AddChildButton.Location = new System.Drawing.Point(187, 41);
            this.AddChildButton.Name = "AddChildButton";
            this.AddChildButton.Size = new System.Drawing.Size(121, 23);
            this.AddChildButton.TabIndex = 4;
            this.AddChildButton.Text = "Add Child";
            this.AddChildButton.UseVisualStyleBackColor = true;
            this.AddChildButton.Click += new System.EventHandler(this.AddChildButton_Click);
            // 
            // TreeViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 369);
            this.Controls.Add(this.AddChildButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ChildNodeComboBox);
            this.Controls.Add(this.NodeTextBox);
            this.Controls.Add(this.treeView);
            this.Name = "TreeViewForm";
            this.Text = "Tree View Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox NodeTextBox;
        private System.Windows.Forms.ComboBox ChildNodeComboBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button AddChildButton;
    }
}

