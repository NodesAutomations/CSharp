using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class TreeViewForm : Form
    {
        public TreeViewForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode(NodeTextBox.Text);
            treeView.Nodes.Add(node);
        }

        private void AddChildButton_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode(ChildNodeComboBox.SelectedItem.ToString());
            treeView.SelectedNode.Nodes.Add(node);
        }
    }
}