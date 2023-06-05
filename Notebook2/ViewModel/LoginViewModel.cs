using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Notebook2.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        [RegularExpression("^[a-zA-Z0-9_.]{4,}$",
            ErrorMessage = "Не правильный логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [RegularExpression("^[a-zA-Z0-9!@#$%^&*()_+{}\\[\\]:;\\\"'<>,.?/\\\\|\\-=`~]{6,}$",
            ErrorMessage = "Не правильный пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}