using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Data
{
    public static class DataRestaurant
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Restaurants.Any())
            {
                context.Restaurants.AddRange(
                    new Restaurant { Name = "Макдоналдс", Category = "Бурнеры", Description = "Фастфуд", Img = "/img/Makdonalds.jpg" },
                    new Restaurant { Name = "KFC", Category = "Бурнеры", Description = "Фастфуд", Img = "/img/KFC.jpg" },
                    new Restaurant { Name = "Burger King", Category = "Бурнеры", Description = "Фастфуд", Img = "/img/Burger King.jpg" },
                    new Restaurant { Name = "SUSHI BOX", Category = "Суши", Description = "Китайская", Img = "/img/SUSHI BOX.jpg" },
                    new Restaurant { Name = "SUSHI BOX", Category = "Суши", Description = "Китайская", Img = "/img/SUSHI BOX.jpg" },
                    new Restaurant { Name = "SUSHI BOX", Category = "Суши", Description = "Китайская", Img = "/img/SUSHI BOX.jpg" }
                    );
                context.SaveChanges();
            }

            if (!context.Foods.Any()) 
            { 
                context.Foods.AddRange(
                    new Food { Name = "Двойной Биг Тейсти Большой МакКомбо", 
                        Category = "McComboo", 
                        Description = "sss", 
                        Price = 425, 
                        Img = "/img/Food/Makdonalds/McComboo/DoubleBigTastyBigMcCombo.jpg"
                    },
                    new Food
                    {
                        Name = "Биг Тейсти МакКомбо Большой",
                        Category = "McComboo",
                        Description = "sss",
                        Price = 349,
                        Img = "/img/Food/Makdonalds/McComboo/BigTastyMcComboBig.jpg"
                    },
                    new Food
                    {
                        Name = "Двойной Роял МакКомбо Большой",
                        Category = "McComboo",
                        Description = "sss",
                        Price = 329,
                        Img = "/img/Food/Makdonalds/McComboo/DoubleRoyaleMcComboLarge.jpg"
                    },
                    new Food
                    {
                        Name = "Двойной Биг Мак Большой МакКОМБО",
                        Category = "McComboo",
                        Description = "sss",
                        Price = 319,
                        Img = "/img/Food/Makdonalds/McComboo/DoubleBigMacBigMcCOMBO.jpg"
                    },
                    new Food
                    {
                        Name = "Биг Тейсти Джуниор Большой МакКомбо",
                        Category = "McComboo",
                        Description = "sss",
                        Price = 305,
                        Img = "/img/Food/Makdonalds/McComboo/BigTastyJuniorBigMcCombo.jpg"
                    },
                    new Food
                    {
                        Name = "Грик Мак Фреш Большой МакКомбо",
                        Category = "McComboo",
                        Description = "sss",
                        Price = 299,
                        Img = "/img/Food/Makdonalds/McComboo/GrickMacFreshBigMcCombo.jpg"
                    },
                    new Food
                    {
                        Name = "Двойной Биг Тейсти",
                        Category = "Sandwiches",
                        Description = "sss",
                        Price = 325,
                        Img = "/img/Food/Makdonalds/Sandwiches/DoubleBigTasty.jpg"
                    },
                    new Food
                    {
                        Name = "Биг Тейсти",
                        Category = "Sandwiches",
                        Description = "sss",
                        Price = 249,
                        Img = "/img/Food/Makdonalds/Sandwiches/BigTasty.jpg"
                    }, new Food
                    {
                        Name = "Двойной Роял",
                        Category = "Sandwiches",
                        Description = "sss",
                        Price = 219,
                        Img = "/img/Food/Makdonalds/Sandwiches/DoubleRoyal.jpg"
                    }, new Food
                    {
                        Name = "Двойной Биг Мак",
                        Category = "Sandwiches",
                        Description = "sss",
                        Price = 199,
                        Img = "/img/Food/Makdonalds/Sandwiches/DoubleBigMac.jpg"
                    },
                    new Food
                    {
                        Name = "Биг Тейсти Джуниор",
                        Category = "Sandwiches",
                        Description = "sss",
                        Price = 185,
                        Img = "/img/Food/Makdonalds/Sandwiches/BigTacyJunior.jpg"
                    },
                    new Food
                    {
                        Name = "Грик Мак Фреш",
                        Category = "Sandwiches",
                        Description = "sss",
                        Price = 175,
                        Img = "/img/Food/Makdonalds/Sandwiches/GrickMacFresh.jpg"
                    }, new Food
                    {
                        Name = "Чикен Грик Мак",
                        Category = "Sandwiches",
                        Description = "sss",
                        Price = 169,
                        Img = "/img/Food/Makdonalds/Sandwiches/ChickenGrickMac.jpg"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.BurgerKings.Any())
            {
                context.BurgerKings.AddRange(
                    new BurgerKing
                    {
                        Name = "Воппер Джуниор",
                        Category = "Бургеры с говядиной",
                        Description = "Приготовленный на огне бифштекс " +
                        "из 100% говядины, сочный помидор, свежий нарезанный " +
                        "салат, густой майонез, хрустящие огурчики и свежий лук на " +
                        "мягкой булочке, посыпанной кунжутом.",
                        Price = 149,
                        Img = "/img/BurgerKing/WhopperJunior.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Воппер",
                        Category = "Бургеры с говядиной",
                        Description = "ВОППЕР® — это вкуснейшая приготовленная на огне " +
                        "100% говядина с сочными помидорами, свежим нарезанным листовым " +
                        "салатом, густым майонезом, хрустящими маринованными огурчиками и " +
                        "свежим луком на нежной булочке с кунжутом.",
                        Price = 199,
                        Img = "/img/BurgerKing/Whopper.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Воппер с сыром",
                        Category = "Бургеры с говядиной",
                        Description = "Приготовленный на огне бифштекс из 100% говядины, два нежных " +
                        "ломтика сыра, сочные помидоры, свежий нарезанный салат, густой майонез, " +
                        "хрустящие огурчики и свежий лук на нежной булочке с кунжутом.",
                        Price = 249,
                        Img = "/img/BurgerKing/WhopperCheese.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Двойной Воппер",
                        Category = "Бургеры с говядиной",
                        Description = "ВОППЕР® — это вкуснейшая приготовленная на огне 100% " +
                        "говядина с сочными помидорами, свежим нарезанным листовым салатом, " +
                        "густым майонезом, хрустящими маринованными огурчиками и свежим луком " +
                        "на нежной булочке с кунжутом.",
                        Price = 289,
                        Img = "/img/BurgerKing/DoubleWopper.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Двойной воппер с сыром",
                        Category = "Бургеры с говядиной",
                        Description = "Двойной ВОППЕР®с сыром - это два аппетитных, приготовленных " +
                        "на огне бифштекса из 100% говядины, два нежных ломтика сыра, сочные " +
                        "помидоры, свежий нарезанный листовой салат, густой майонез, хрустящие " +
                        "маринованные огурчики и свежий лук на нежной булочке с кунжутом.",
                        Price = 329,
                        Img = "/img/BurgerKing/DoubleWopperCheese.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Комбо с Воппером",
                        Category = "Выгодные Комбо",
                        Description = "Легендарный Воппер со 100% говядиной, хрустящая Кинг Фри, " +
                        "золотистые луковые колечки, нежные куринные наггетсы и Pepsi",
                        Price = 349,
                        Img = "/img/BurgerKing/DoubleWopper.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Под Сериальчик комбо",
                        Category = "Выгодные Комбо",
                        Description = "Умножаем все на 3! 3 Классических Воппера или Лонг Чикена, 3 " +
                        "порции нежных наггетсов, 3 хрустящих Кинг Фри, 3 соуса и 3 Pepsi",
                        Price = 999,
                        Img = "/img/BurgerKing/UnderSerialchikCombo.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Комбо с Цезарь Кингом",
                        Category = "Выгодные Комбо",
                        Description = "Пикантный Цезарь Кинг, хрустящая Кинг Фри и Pepsi",
                        Price = 179,
                        Img = "/img/BurgerKing/CombowithCaesarKing.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "Комбо со Стейкхаусом",
                        Category = "Выгодные Комбо",
                        Description = "Хит! Сочный Стейкхаус, хрустящая Кинг Фри, золотистые " +
                        "луковые колечки, нежные куриные наггетсы и бутылка освещающей Pepsi",
                        Price = 399,
                        Img = "/img/BurgerKing/ComboWithSteakhouse.jpg"
                    },
                    new BurgerKing
                    {
                        Name = "БольшоекомбосЧизбургером",
                        Category = "Выгодные Комбо",
                        Description = "2 фирменных Чизбургера, золотистая Кинг Фри, 2 соуса, " +
                        "нежные куриные наггетсы и Pepsi",
                        Price = 399,
                        Img = "/img/BurgerKing/LargeCombosCheeseburger.jpg"
                    }

                    );
                context.SaveChanges();
            }

            if (!context.DominoPizzas.Any())
            {
                context.DominoPizzas.AddRange(
                    new DominoPizza
                    {
                        Name = "Сырная с ветчиной, Большая",
                        Category = "Пицца",
                        Description = "Ветчина, Сыр Моцарелла",
                        Price = 499,
                        Img = "/img/Domino Pizza/Сырная с ветчиной, Большая.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Пепперони по-деревенски, Большая",
                        Category = "Пицца",
                        Description = "Огурцы маринованные, Пепперони, Сыр Моцарелла",
                        Price = 499,
                        Img = "/img/Domino Pizza/Пепперони по-деревенски, Большая.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Пепперони, Большая",
                        Category = "Пицца",
                        Description = "Пепперони, Сыр Моцарелла",
                        Price = 599,
                        Img = "/img/Domino Pizza/Пепперони, Большая.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Домино'c, Большая",
                        Category = "Пицца",
                        Description = "Бекон, Говядина, Грибы, Курица, Лук, Сыр Пармезан, " +
                        "Пепперони, Болгарский перец, Свежие томаты, Свинина, Сыр Моцарелла",
                        Price = 849,
                        Img = "/img/Domino Pizza/Домино'c, Большая.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Маргарита Гурме, Большая",
                        Category = "Пицца",
                        Description = "Свежие томаты, Сыр Моцарелла",
                        Price = 499,
                        Img = "/img/Domino Pizza/Маргарита Гурме, Большая.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Сырная с ветчиной, Средняя",
                        Category = "Пицца",
                        Description = "Ветчина, Сыр Моцарелла",
                        Price = 399,
                        Img = "/img/Domino Pizza/Сырная с ветчиной, Средняя.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Пепперони по-деревенски, Средняя",
                        Category = "Пицца",
                        Description = "Огурцы маринованные, Пепперони, Сыр Моцарелла",
                        Price = 399,
                        Img = "/img/Domino Pizza/Пепперони по-деревенски, Средняя.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Пепперони, Средняя",
                        Category = "Пицца",
                        Description = "Пепперони, Сыр Моцарелла",
                        Price = 499,
                        Img = "/img/Domino Pizza/Пепперони, Средняя.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Домино'c, Средняя",
                        Category = "Пицца",
                        Description = "Бекон, Говядина, Грибы, Курица, Лук, Сыр Пармезан, " +
                        "Пепперони, Болгарский перец, Свежие томаты, Свинина, Сыр Моцарелла",
                        Price = 749,
                        Img = "/img/Domino Pizza/Домино'c, Большая.jpg"
                    },
                    new DominoPizza
                    {
                        Name = "Маргарита Гурме, Средняя",
                        Category = "Пицца",
                        Description = "Свежие томаты, Сыр Моцарелла",
                        Price = 399,
                        Img = "/img/Domino Pizza/Маргарита Гурме, Средняя.jpg"
                    }
                    );
                context.SaveChanges();
            }
            
            if (!context.Kfcs.Any())
            {
                context.Kfcs.AddRange(
                    new Kfc
                    {
                        Name = "Домашний Баскет",
                        Category = "Баскеты",
                        Description = "10 острых крылышек, 8 Стрипсов " +
                        "оригинальные или острые на выбор,6 куриных ножек.",
                        Price = 699,
                        Img = "/img/KFC/Домашний Баскет.jpg"
                    },
                    new Kfc
                    {
                        Name = "Домашний Баскет ХL",
                        Category = "Баскеты",
                        Description = "12 острых крылышек,12 Стрипсов оригинальные " +
                        "или острые на выбор, 6 куриных ножек, Баскет Фри большой.",
                        Price = 999,
                        Img = "/img/KFC/Домашний Баскет ХL.jpg"
                    },
                    new Kfc
                    {
                        Name = "Баскет Дуэт с оригинальными стрипсами",
                        Category = "Баскеты",
                        Description = "Всемирно известные хиты от KFC в нашем Баскете! Для вас " +
                        "мы собрали отличную компанию – сочные кусочки курицы, обжигающе острые " +
                        "крылья, нежнейшие стрипсы и картофель фри. Много не бывает! В состав " +
                        "баскета входят: 2 ножки, 4 острых куриных крыла*, 4 стрипса.",
                        Price = 409,
                        Img = "/img/KFC/Баскет Дуэт с оригинальными стрипсами.jpg"
                    },
                    new Kfc
                    {
                        Name = "Баскет Дуэт с острыми стрипсами",
                        Category = "Баскеты",
                        Description = "Всемирно известные хиты от KFC в нашем Баскете! Для вас мы " +
                        "собрали отличную компанию – сочные кусочки курицы, обжигающе острые крылья, " +
                        "нежнейшие стрипсы и картофель фри. Много не бывает! В состав баскета входят: " +
                        "2 ножки, 4 острых куриных крыла*, 4 стрипса.",
                        Price = 409,
                        Img = "/img/KFC/Баскет Дуэт с острыми стрипсами.jpg"
                    },
                    new Kfc
                    {
                        Name = "Баскет 5 ножек",
                        Category = "Баскеты",
                        Description = "Баскетов много не бывает. Встречайте новинку! " +
                        "Баскет 5 ножек, 2 картофеля фри малых.",
                        Price = 349,
                        Img = "/img/KFC/Баскет 5 ножек.jpg"
                    },
                    new Kfc
                    {
                        Name = "Шефбургер",
                        Category = "Бургеры",
                        Description = "Попробуйте новый уникальный бургер от шефа! Нежный " +
                        "сливочный соус, сочное филе в оригинальной панировке, салат айcберг " +
                        "и помидоры на пшеничной булочке с черно-белым кунжутом.",
                        Price = 134,
                        Img = "/img/KFC/Шефбургер.jpg"
                    },
                    new Kfc
                    {
                        Name = "Острый Шефбургер",
                        Category = "Бургеры",
                        Description = "Попробуйте новый уникальный бургер от шефа! острая " +
                        "курочка в панировке Hot&spicy, сочные листья салата, пикантные " +
                        "маринованные огурчики, лук, фирменный соус Бургер и булочка с " +
                        "черно-белым кунжутом.",
                        Price = 134,
                        Img = "/img/KFC/Острый Шефбургер.jpg"
                    },
                    new Kfc
                    {
                        Name = "Шефбургер Де Люкс",
                        Category = "Бургеры",
                        Description = "Бургер от шефа теперь Де Люкс! Сочное филе в " +
                        "оригинальной панировке, томаты, салат айсберг, соус Цезарь," +
                        " аппетитная булочка, нежный сыр и бекон!.",
                        Price = 144,
                        Img = "/img/KFC/Шефбургер Де Люкс.jpg"
                    },
                    new Kfc
                    {
                        Name = "Острый Шефбургер Де Люкс",
                        Category = "Бургеры",
                        Description = "Острый бургер от шефа теперь де Люкс! острое филе " +
                        "в хрустящей панировке, салат айсберг, маринованные огурцы, лук, " +
                        "фирменный соус Бургер, булочка с кунжутом, нежный сыр и сочный бекон!.",
                        Price = 144,
                        Img = "/img/KFC/Острый Шефбургер Де Люкс.jpg"
                    },
                    new Kfc
                    {
                        Name = "Чизбургер Де Люкс",
                        Category = "Бургеры",
                        Description = "Пряный горчичный соус, кетчуп, сочное филе в оригинальной " +
                        "панировке, лук, сыр Чеддер, огурцы на пшеничной булочке с кукурузной " +
                        "посыпкой, свежий салат и ломтики помидора.",
                        Price = 124,
                        Img = "/img/KFC/Чизбургер Де Люкс.jpg"
                    }
                    );
                context.SaveChanges();
            }
            
            if (!context.MyBoxes.Any())
            {
                context.MyBoxes.AddRange(
                    new MyBox
                    {
                        Name = "Баланс комбо",
                        Category = "Комбо",
                        Description = "300 г  223,1 ккал Салат цезарь " +
                        "с курицей (1 шт.), Ролл бонито (1 шт.). 223,1 ккал/100 г",
                        Price = 245,
                        Img = "/img/MyBox/Баланс комбо.jpg"
                    },
                    new MyBox
                    {
                        Name = "Бэнто комбо",
                        Category = "Комбо",
                        Description = "345 г  256,3 ккал Салат цезарь с курицей (1 шт.), " +
                        "Ролл хоккайдо (белый соус) (1 шт.). 256,3 ккал/100 г",
                        Price = 245,
                        Img = "/img/MyBox/Бэнто комбо.jpg"
                    },
                    new MyBox
                    {
                        Name = "Овощное комбо",
                        Category = "Комбо",
                        Description = "340 г  172,0 ккал Салат чука (1 шт.), Ролл овощной " +
                        "(1 шт.). 172,0 ккал/100 г",
                        Price = 245,
                        Img = "/img/MyBox/Овощное комбо.jpg"
                    },
                    new MyBox
                    {
                        Name = "Сумо комбо",
                        Category = "Комбо",
                        Description = "310 г  278,9 ккал Салат цезарь с курицей (1 шт.), " +
                        "Ролл сансей (белый соус) (1 шт.). 278,9 ккал/100 г",
                        Price = 245,
                        Img = "/img/MyBox/Сумо комбо.jpg"
                    },
                    new MyBox
                    {
                        Name = "Сет l-box",
                        Category = "Японское меню",
                        Description = "370 г  241,0 ккал Ролл лосось (0,5 шт.), " +
                        "Суши спайси краб (1 шт.), Суши лосось (1 шт.), " +
                        "Ролл огурец (0,5 шт.), Ролл филадельфия спешл (1 шт.). 241,0 ккал/100 г",
                        Price = 345,
                        Img = "/img/MyBox/Сет l-box.jpg"
                    },
                    new MyBox
                    {
                        Name = "Сет m-box",
                        Category = "Японское меню",
                        Description = "390 г  230,2 ккал Суши спайси краб (2 шт.), Ролл калифорния " +
                        "классик (0,5 шт.), Ролл лайт (1 шт.). 230,2 ккал/100 г",
                        Price = 295,
                        Img = "/img/MyBox/Сет m-box.jpg"
                    },
                    new MyBox
                    {
                        Name = "Сет африка (стандарт)",
                        Category = "Японское меню",
                        Description = "880 г  257,0 ккал Ролл сансей (белый соус) (1 шт.), Ролл калифорния " +
                        "с лососем (1 шт.), Ролл филадельфия спешл (1 шт.), Ролл филадельфия с лососем и крабом " +
                        "(спайси соус) (1 шт.). 257,0 ккал/100 г",
                        Price = 720,
                        Img = "/img/MyBox/Сет африка (стандарт).jpg"
                    },
                    new MyBox
                    {
                        Name = "Сет инь-янь",
                        Category = "Японское меню",
                        Description = "710 г  213,0 ккал Ролл хоккайдо (белый соус) (1 шт.), Ролл филадельфия с " +
                        "лососем и крабом (спайси соус) (1 шт.), Ролл итальянский (1 шт.). 213,0 ккал/100 г",
                        Price = 635,
                        Img = "/img/MyBox/Сет инь-янь.jpg"
                    },
                    new MyBox
                    {
                        Name = "Сет огонь (стандарт)",
                        Category = "Японское меню",
                        Description = "600 г  233,7 ккал Ролл креветка (1 шт.), Ролл лосось (1 шт.), " +
                        "Ролл огурец (1 шт.), Ролл вулкан (1 шт.). 233,7 ккал/100 г",
                        Price = 450,
                        Img = "/img/MyBox/Сет инь-янь.jpg"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.SushiBoxes.Any())
            {
                context.SushiBoxes.AddRange(
                    new SushiBox
                    {
                        Name = "Ролл ямаки",
                        Category = "Роллы",
                        Description = "210 г  Снежный краб, угорь, огурец, сыр, кунжут.",
                        Price = 199,
                        Img = "/img/Sushi Box/Ролл ямаки.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Ролл хатано",
                        Category = "Роллы",
                        Description = "215 г  Бекон, куриное филе, огурец, сыр, укроп, соус спайси.",
                        Price = 211,
                        Img = "/img/Sushi Box/Ролл хатано.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Ролл ниппон",
                        Category = "Роллы",
                        Description = "200 г  Снежный краб, лосось, огурец, сыр.",
                        Price = 199,
                        Img = "/img/Sushi Box/Ролл ниппон.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Ролл крейзи краб",
                        Category = "Роллы",
                        Description = "230 г  Снежный краб, огурец, сыр, масаго.",
                        Price = 199,
                        Img = "/img/Sushi Box/Ролл крейзи краб.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Чикен ролл акция",
                        Category = "Роллы",
                        Description = "230 г  Куриное филе, сыр, огурец, кунжут.",
                        Price = 199,
                        Img = "/img/Sushi Box/Чикен ролл акция.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Ролл чикен hot",
                        Category = "Запеченные роллы",
                        Description = "280 г  Куриное филе, сыр, огурец, унаги, кунжут, моцарелла.",
                        Price = 229,
                        Img = "/img/Sushi Box/Ролл чикен hot.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Ролл тори hot",
                        Category = "Запеченные роллы",
                        Description = "250 г  Куриное филе, сыр, огурец, унаги, соус терияки, моцарелла.",
                        Price = 229,
                        Img = "/img/Sushi Box/Ролл тори hot.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Запеченный окунь",
                        Category = "Запеченные роллы",
                        Description = "240 г  Окунь, сыр, огурец, соус, кунжут.",
                        Price = 229,
                        Img = "/img/Sushi Box/Запеченный окунь.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Ролл ямаки hot",
                        Category = "Запеченные роллы",
                        Description = "250 г  Снежный краб, угорь, огурец, сыр, кунжут, соус.",
                        Price = 224,
                        Img = "/img/Sushi Box/Ролл ямаки hot.jpg"
                    },
                    new SushiBox
                    {
                        Name = "Ролл ниппон hot",
                        Category = "Запеченные роллы",
                        Description = "240 г  Снежный краб, лосось, огурец, сыр, соус.",
                        Price = 224,
                        Img = "/img/Sushi Box/Ролл ниппон hot.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
