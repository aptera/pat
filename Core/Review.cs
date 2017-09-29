﻿using System.ComponentModel.DataAnnotations;

namespace TotallyNotRobots.Movies.Models
{
    public class Review
    {
        public int ID { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}
