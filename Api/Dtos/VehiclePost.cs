using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class VehiclePost
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Series { get; set; }

        [Required]
        [Range(1, 1000000000)]
        public uint Number { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Color { get; set; }

        [Required]
        [VehicleType]
        public string Type { get; set; }
    }
}
