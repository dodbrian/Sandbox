using System;

namespace CompositionOverInheritance.Entitites
{
    internal class Label : NamedEntity, ITrackable
    {
        public string IconName { get; set; }

        public DateTime CreatedOn
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string CreatedBy
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public DateTime ModifiedOn
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string ModifiedBy
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}