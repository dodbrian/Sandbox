using System;

namespace CompositionOverInheritance.Entitites
{
    class Label : NamedEntity, ITrackable
    {
        public Label()
        {
        }

        public string IconName { get; set; }

        public DateTime CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ModifiedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}