using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Notebook2.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле Логин обязательно для заполнения")]
        [Display(Name = "Логин")]
        [RegularExpression("^[a-zA-Z0-9_.]{4,}$",
            ErrorMessage = "Не правильный логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [Display(Name = "Пароль")]
        [RegularExpression("^[a-zA-Z0-9!@#$%^&*()_+{}\\[\\]:;\\\"'<>,.?/\\\\|\\-=`~]{6,}$",
            ErrorMessage = "Не правильный пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}