namespace CustomDialogs
{
  partial class TypeViewerForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(314, 65);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(78, 24);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object type";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(79, 22);
            this.typeTextBox.Multiline = true;
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(279, 37);
            this.typeTextBox.TabIndex = 2;
            // 
            // TypeViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 101);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Name = "TypeViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Type Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox typeTextBox;
  }
}