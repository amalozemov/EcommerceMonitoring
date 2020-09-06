using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Требуется поле 'Имя'.")]
        [Display(Name = "Имя:")]
        [StringLength(8, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 8 символов.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Требуется поле 'Пароль'.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль:")]
        [StringLength(8, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 8 символов.")]
        public string Password { get; set; }
    }
}