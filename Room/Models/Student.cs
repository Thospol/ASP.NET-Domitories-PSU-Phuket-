using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Room.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Student ID is required.")]

        public string StudentID { get; set; }
        [Required(ErrorMessage = "Firtname is required.")]

        public string Fname { get; set; }
        [Required(ErrorMessage = "Lastname is required.")]

        public string Lname { get; set; }

        public string Phone { get; set; }
        public string RoomNo { get; set; }
        

    }
}