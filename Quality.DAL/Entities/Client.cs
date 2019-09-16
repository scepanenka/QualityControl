using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quality.DAL.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Личный номер")]
        public string PersonalNumber { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        public int? TypeClient { get; set; }
        [Display(Name = "УНН")]
        public string Unn { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime? BothDate { get; set; }
        [Display(Name = "Примечание")]
        public string Information { get; set; }
    }
}
