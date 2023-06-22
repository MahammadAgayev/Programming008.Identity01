using System.ComponentModel.DataAnnotations;

namespace Programming008.Identity01.Models
{
    public class SignUpModel
    {
        [Required(AllowEmptyStrings = false)]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string? Password { get; set; }
    }
}
