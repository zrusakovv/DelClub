using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models
{
    public class Makdonalds
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public int Price { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
    }

    public class MDOrder
    {
        [Key]
        [BindNever]
        public int Id { get; set; }

        [BindNever]
        public ICollection<MDCartLine> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }

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
