using System.ComponentModel.DataAnnotations;

namespace Bandwagon.DTOs
{
    public class CommandUpdateDTO
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
    }