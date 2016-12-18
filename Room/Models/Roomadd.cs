using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Room.Models
{
    public class Roomadd
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Rom no. is required.")]
        public string RoomNo { get; set; }

        [Required(ErrorMessage = "Room Type is required.")]
        public string Roomtype { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        public string StudentID { get; set; }

        public string StudentID2 { get; set; }
    }

}