using DelClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    //Модель представления
    public class MakdonaldsListViewModel
    {
        //Список элементов BurgerKing
        public IEnumerable<Makdonalds> Makdonalds { get; set; }
        //Переменная для хранения текущей категории
        public string CurrentCategory { get; set; }

        public CartMakdonalds Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
