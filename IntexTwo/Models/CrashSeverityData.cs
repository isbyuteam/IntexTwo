                                                                                                                                                                         using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntexTwo.Models
{
    public class CrashSeverityData
    {
        public float crash_severity_id { get; set; }
        public float minute { get; set; }
        public float day { get; set; }
        public float hour { get; set; }
        public float month { get; set; }
        [Range(0, 1)]
        public float motorcycle_involved_True { get; set; }
        [Range(0, 1)]
        public float pedestrian_involved_True { get; set; }
        [Range(0, 1)]
        public float overturn_rollover_True { get; set; }
        [Range(0, 1)]
        public float bicyclist_involved_True { get; set; }
        public float year { get; set; }
        [Range(0, 1)]
        public float teenage_driver_involved_True { get; set; }
        [Range(0, 1)]
        public float day_of_week_Tuesday { get; set; }
        [Range(0, 1)]
        public float day_of_week_Monday { get; set; }
        [Range(0, 1)]
        public float unrestrained_True { get; set; }
        [Range(0, 1)]
        public float day_of_week_Saturday { get; set; }
        [Range(0, 1)]
        public float day_of_week_Wednesday { get; set; }
        [Range(0, 1)]
        public float day_of_week_Thursday { get; set; }
        [Range(0, 1)]
        public float night_dark_condition_True { get; set; }
        [Range(0, 1)]
        public float roadway_departure_True { get; set; }
        [Range(0, 1)]
        public float older_driver_involved_True { get; set; }
        [Range(0, 1)]
        public float single_vehicle_True { get; set; }
        [Range(0, 1)]
        public float day_of_week_Sunday { get; set; }
        [Range(0, 1)]
        public float wild_animal_related_True { get; set; }
        [Range(0, 1)]
        public float intersection_related_True { get; set; }
        [Range(0, 1)]
        public float dui_True { get; set; }
        [Range(0, 1)]
        public float work_zone_related { get; set; }
        [Range(0, 1)]
        public float improper_restraint_True { get; set; }
        [Range(0, 1)]
        public float city_PROVO { get; set; }
        [Range(0, 1)]
        public float distracted_driving_True { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                crash_severity_id,
                minute, day, hour,month,
                motorcycle_involved_True,
                pedestrian_involved_True,
                overturn_rollover_True,
                bicyclist_involved_True,
                year,
                teenage_driver_involved_True,
                day_of_week_Tuesday,
                day_of_week_Monday,
                unrestrained_True,
                day_of_week_Saturday,
                day_of_week_Wednesday,
                day_of_week_Thursday,
                night_dark_condition_True,
                roadway_departure_True,
                older_driver_involved_True,
                single_vehicle_True,
                day_of_week_Sunday,
                wild_animal_related_True,
                intersection_related_True,
                dui_True,
                work_zone_related,
                improper_restraint_True,
                city_PROVO,
                distracted_driving_True
            };
            int[] dimensions = new int[] { 1, 29 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}

