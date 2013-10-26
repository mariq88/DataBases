using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();

            this.homeworks = new HashSet<Homework>();
        }

        [Key]
        public int CourseID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }



        public virtual ICollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
