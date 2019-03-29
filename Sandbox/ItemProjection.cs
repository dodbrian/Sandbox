using System;
using System.Linq.Expressions;

namespace Sandbox
{
    public class ItemProjection
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ParentShort Parent { get; set; }

        public static Expression<Func<Item, ItemProjection>> Projection
        {
            get
            {
                return x => new ItemProjection
                {
                    Id = x.Id,
                    Name = x.Name,
                    Parent = ParentShort.FromEntity(x.Parent)
                };
            }
        }
    }
}