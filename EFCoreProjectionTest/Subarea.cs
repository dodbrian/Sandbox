using System;

namespace EFCoreProjectionTest
{
    public class Subarea
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AreaId { get; set; }

        public Area Area { get; set; }
    }
}
