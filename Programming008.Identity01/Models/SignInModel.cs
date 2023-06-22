using System.ComponentModel.DataAnnotations;

namespace Programming008.Identity01.Models
{
    public class SignInModel
    {
        [Required(AllowEmptyStrings = false)]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings =  false)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
