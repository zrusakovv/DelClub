using DelClub.Models;
using DelClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    //Модель представления
    public class DominoPizzaListViewModel
    {
        //Список элементов BurgerKing
        public IEnumerable<DominoPizza> DominoPizzas { get; set; }
        //Переменная для хранения текущей категории
        public string CurrentCategory { get; set; }
        public CartDominoPizza Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
