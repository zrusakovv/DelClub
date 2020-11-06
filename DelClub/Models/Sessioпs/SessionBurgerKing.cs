using DelClub.Infrastructure;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace DelClub.Models.Sessioпs
{
    public class SessionBurgerKing : CartBurgerKing
    {
        public static CartBurgerKing GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionBurgerKing cart = session?.GetJson<SessionBurgerKing>("CartBurgerKing") ?? new SessionBurgerKing();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(BurgerKing burgerKing, int quantity)
        {
            base.AddItem(burgerKing, quantity);
            Session.SetJson("CartBurgerKing", this);
        }

        public override void RemoveLine(BurgerKing burgerKing)
        {
            base.RemoveLine(burgerKing);
            Session.SetJson("CartBurgerKing", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("CartBurgerKing");
        }
    }
}
