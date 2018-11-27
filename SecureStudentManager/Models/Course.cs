﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureStudentManager.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string CourseDescription { get; set; }
        public int DepartmentID { get; set; }
    }
}