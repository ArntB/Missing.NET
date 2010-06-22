using System.Windows.Forms;

namespace Missing.Windows.Forms
{
    public static class TreeViewExtensions
    {
        public static TreeNode AddNode(this TreeView self, TreeNode node)
        {
            self.Nodes.Add(node);
            return node;
        }

        public static TreeNode AddNode(this TreeView self, string text)
        {
            TreeNode node = new TreeNode(text);
            self.AddNode(node);
            return node;
        }

        public static TreeNode AddNode(this TreeNode self, TreeNode node)
        {
            self.Nodes.Add(node);
            return node;
        }

        public static TreeNode AddNode(this TreeNode self, string text)
        {
            TreeNode node = new TreeNode(text);
            self.AddNode(node);
            return node;
        }

    }
}