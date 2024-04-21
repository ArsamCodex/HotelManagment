﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class RoomInspection
    {
        public int RoomInspectionID { get; set; }
        [Required(ErrorMessage = "RoomNumber is required")]
        public int? RoomNumber { get; set; }
        public DateTime? InspectionDate { get; set; }
        [Required(ErrorMessage = "ProblemDescription is required")]
        public string? ProblemDescription { get; set; }
        public string Staff { get; set; }
        public RepairCondition COnditions { get; set; }
        public bool NeedRepair { get; set; }
        public DateTime? StartReperation { get; set; }
        public DateTime? EndReperation { get; set; }
    }
}