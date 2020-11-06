using DelClub.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace DelClub.Models.Sessioпs
{
    public class SessioпCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessioпCart cart = session?.GetJson<SessioпCart>("Cart") ?? new SessioпCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Food food, int quantity)
        {
            base.AddItem(food, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Food food)
        {
            base.RemoveLine(food);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
