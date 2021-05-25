using System.Collections.Generic;

namespace Replace.Models //Replace namespace with namespace being
{
    public class ParentClass //change name to parent class
    {
        public ParentClass() //when does this get called?
        {
            this.ChildClasses = new HashSet<ChildClass>(); // First Child is plural and second child is singular
        }

        public int ParentClassId { get; set; } //replace parent class
        public string AnyField { get; set; } //Replace with field name
        public virtual ICollection<ChildClass> ChildClasses { get; set; }
    }
}