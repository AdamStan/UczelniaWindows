//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UczelniaWindows
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.StudentToSubjects = new HashSet<StudentToSubject>();
        }
    
        public int index_number { get; set; }
        public string password { get; set; }
        public string s_name { get; set; }
        public string surname { get; set; }
        public string field_of_study { get; set; }
        public string degree { get; set; }
        public string mode { get; set; }
        public int semester { get; set; }
        public Nullable<int> faculty_id { get; set; }
    
        public virtual Faculty Faculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentToSubject> StudentToSubjects { get; set; }
    }
}