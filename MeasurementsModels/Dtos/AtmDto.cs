using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementsModels.Dtos
{
    public class AtmDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Hash { get; set; }
    }
}
