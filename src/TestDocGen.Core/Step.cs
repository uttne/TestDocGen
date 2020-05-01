namespace TestDocGen
{
    public class Step
    {
        public string No { get; set; }
        public string Content { get; set; }
        public string Validation { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Step);
        }

        protected bool Equals(Step other)
        {
            if (other == null)
                return false;
            return No == other.No 
                   && Content == other.Content 
                   && Validation == other.Validation;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (No != null ? No.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Content != null ? Content.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Validation != null ? Validation.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}