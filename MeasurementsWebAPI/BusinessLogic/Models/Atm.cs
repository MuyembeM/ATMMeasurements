using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeasurementsWebAPI.BusinessLogic.Models
{
    public partial class Atm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Length { get; set; }

        [Required]
        [Range(0, 800)]
        public int Width { get; set; }

        [Required]
        [Range(100, int.MaxValue)]
        public int Height { get; set; }
    }
}
