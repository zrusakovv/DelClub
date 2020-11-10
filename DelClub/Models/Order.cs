using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }


        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите название города")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите адрес проживани")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите номер дома")]
        public string Entrance { get; set; }

        [Required(ErrorMessage = "Введите номер подъезда")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Введите номер квартиры")]
        public string Apartment { get; set; }
    }
}
