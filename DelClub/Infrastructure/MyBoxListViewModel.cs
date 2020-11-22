using DelClub.Models;
using DelClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    //Модель представления
    public class MyBoxListViewModel
    {
        //Список элементов BurgerKing
        public IEnumerable<MyBox> MyBoxes { get; set; }
        //Переменная для хранения текущей категории
        public string CurrentCategory { get; set; }
        public CartMyBox Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
