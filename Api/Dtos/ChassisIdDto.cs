using System.ComponentModel.DataAnnotations;
namespace Api.Dtos
{
    public class ChassisIdDto
    {
        [Required]
        public string Series { get; set; }
        [Required]
        public uint Number { get; set; }
    }
}