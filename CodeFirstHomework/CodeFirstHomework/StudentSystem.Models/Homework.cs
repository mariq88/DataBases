﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StudentSystem.Models
{
    public class Homework
    {
        public Homework()
        {
        }

        [Key]
        public int HomeworkID { get; set; }

        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Student Student { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }
    }
}
