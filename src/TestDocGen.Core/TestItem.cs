using System.Collections.Generic;
using System.Linq;

namespace TestDocGen
{
    public class TestItem
    {
        public string Chapter { get; set; }
        public string Section { get; set; }
        public string Name { get; set; }
        public IList<string> Tags { get; set; }
        public string Description { get; set; }
        public IList<Step> Steps { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as TestItem);
        }

        protected bool Equals(TestItem other)
        {
            if (other == null)
                return false;
            return Chapter == other.Chapter 
                   && Section == other.Section 
                   && Name == other.Name
                   && (ReferenceEquals(Tags, other.Tags) || Tags != null & other.Tags != null && Tags.SequenceEqual(other.Tags))
                   && Description == other.Description
                   && (ReferenceEquals(Steps, other.Steps) || Steps != null & other.Steps != null && Steps.SequenceEqual(other.Steps));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Chapter != null ? Chapter.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Section != null ? Section.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Steps != null ? Steps.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}