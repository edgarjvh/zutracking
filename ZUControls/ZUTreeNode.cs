using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZUControls
{
    public class ZUTreeNode : TreeNode
    {
        public ZUTreeNode()
        {

        }

        public int ClientId { get; set; } = 0;
        public int ClientStatus { get; set; } = 1;
    }
}
