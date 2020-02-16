using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Profiles
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage ="Вы обязаны ввести фамилию")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Вы обязаны ввести имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Вы обязаны ввести отчество")]
        public string Patronymic { get; set; }
        [Required]
        [MinLength(12, ErrorMessage = "Поле принимает меньше 12 цифр")]
        [MaxLength(12, ErrorMessage = "Поле принимает меньше 12 цифр")]
        public long IIN { get; set; }
    }
}
