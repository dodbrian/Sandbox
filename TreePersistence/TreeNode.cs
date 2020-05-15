using System;
using System.Collections.Generic;

namespace TreePersistence
{
    public class TreeNode
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public TreeNode Parent { get; set; }

        public IEnumerable<TreeNode> Children { get; set; }
    }
}
