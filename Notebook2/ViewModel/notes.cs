using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Notebook2.ViewModel
{
    public class notes
    {
        [Key] public int idnote { get; set; }
        public int iduser { get; set; }        

        [Required(ErrorMessage = "Поле обязательное для заполнения!")]
        [Display(Name = "Запись")]
        public string? note { get; set; }

        [Required(ErrorMessage ="Введите дату")]
        [Display(Name = "Дата")]
        public DateTime date { get; set; }

        [Display(Name = "Описание")]
        public string? description { get; set; }
    }
}
