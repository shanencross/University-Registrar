using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
    public class Student
    {
        public Student() 
        {
            this.JoinEntities = new HashSet<CourseStudent>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public virtual ICollection<CourseStudent> JoinEntities { get; set; }
    }
}