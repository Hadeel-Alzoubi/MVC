﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class StudentDetails
    {
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Student Student { get; set; }

    }
}