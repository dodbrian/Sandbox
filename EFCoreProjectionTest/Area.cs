using System;
using System.Collections.Generic;

namespace EFCoreProjectionTest
{
    public class Area
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Subarea> Subareas { get; set; }
    }
}
