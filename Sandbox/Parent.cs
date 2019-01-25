using System.Collections.Generic;

namespace Sandbox
{
    public class Parent
    {
        public int Id { get; set; }

        public string ChildName { get; set; }

        public IList<Item> Items { get; set; }
    }
}
