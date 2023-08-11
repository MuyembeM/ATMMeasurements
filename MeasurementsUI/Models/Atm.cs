using System.ComponentModel.DataAnnotations;

namespace MeasurementsUI.Models
{
    public class Atm
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Length cannot be less than 0.")]
        public int Length { get; set; }

        [Required]
        [Range(0, 800, ErrorMessage = "Width cannot be less than 0 or greater than 800.")]
        public int Width { get; set; }

        [Required]
        [Range(100, int.MaxValue, ErrorMessage = "Height cannot be less than 100.")]
        public int Height { get; set; }
    }
}
