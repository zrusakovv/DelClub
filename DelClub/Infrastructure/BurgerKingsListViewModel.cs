using DelClub.Models;
using DelClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    //Модель представления
    public class BurgerKingsListViewModel
    {
        //Список элементов BurgerKing
        public IEnumerable<BurgerKing> BurgerKings { get; set; }
        //Переменная для хранения текущей категории
        public string CurrentCategory { get; set; }

        public CartBurgerKing Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
