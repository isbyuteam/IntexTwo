﻿using System;
using System.ComponentModel.DataAnnotations;

namespace IntexTwo.Models
{
    public class CrashModel
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }
        [Required(ErrorMessage = "Please enter a crash date")]
        public string CRASH_DATE { get; set; }
        [Required(ErrorMessage = "Please enter a city time")]
        public string CRASH_TIME { get; set; }
        [Required(ErrorMessage = "Please enter a route")]
        public int ROUTE { get; set; }
        [Required(ErrorMessage = "Please enter a milepoint")]
        public double MILEPOINT { get; set; }
        [Required(ErrorMessage = "Please enter a latitude")]
        public double LAT_UTM_Y { get; set; }
        [Required(ErrorMessage = "Please enter a city longitude")]
        public double LONG_UTM_X { get; set; }
        [Required(ErrorMessage = "Please enter road name")]
        public string MAIN_ROAD_NAME { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string CITY { get; set; }
        [Required(ErrorMessage = "Please enter a county name")]
        public string COUNTY_NAME { get; set; }
        [Required(ErrorMessage = "Please enter a crash severity")]
        public int CRASH_SEVERITY_ID { get; set; }
        public bool WORK_ZONE_RELATED { get; set; }
        public bool PEDESTRIAN_INVOLVED { get; set; }
        public bool BICYCLIST_INVOLVED { get; set; }
        public bool MOTORCYCLE_INVOLVED { get; set; }
        public bool IMPROPER_RESTRAINT { get; set; }
        public bool UNRESTRAINED { get; set; }
        public bool DUI { get; set; }
        public bool INTERSECTION_RELATED { get; set; }
        public bool WILD_ANIMAL_RELATED { get; set; }
        public bool DOMESTIC_ANIMAL_RELATED { get; set; }
        public bool OVERTURN_ROLLOVER { get; set; }
        public bool COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        public bool TEENAGE_DRIVER_INVOLVED { get; set; }
        public bool OLDER_DRIVER_INVOLVED { get; set; }
        public bool NIGHT_DARK_CONDITION { get; set; }
        public bool SINGLE_VEHICLE { get; set; }
        public bool DISTRACTED_DRIVING { get; set; }
        public bool DROWSY_DRIVING { get; set; }
        public bool ROADWAY_DEPARTURE { get; set; }
    }
}
