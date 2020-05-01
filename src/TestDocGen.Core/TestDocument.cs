using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDocGen
{
    public class TestDocument
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string SubTitle { get; set; }
        public IList<TestItem> Tests { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as TestDocument);
        }

        protected bool Equals(TestDocument other)
        {
            if (other == null)
                return false;

            return Description == other.Description 
                   && Id.Equals(other.Id) 
                   && SubTitle == other.SubTitle
                   && (ReferenceEquals(Tests, other.Tests) || Tests != null & other.Tests != null && Tests.SequenceEqual(other.Tests))
                   && Title == other.Title 
                   && Version == other.Version;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (SubTitle != null ? SubTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tests != null ? Tests.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
