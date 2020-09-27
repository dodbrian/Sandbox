using System;

namespace CompositionOverInheritance.Entities
{
    internal interface ITrackable
    {
        DateTime CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTime ModifiedOn { get; set; }

        string ModifiedBy { get; set; }
    }
}