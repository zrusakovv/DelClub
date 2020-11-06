using DelClub.Infrastructure;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace DelClub.Models.Sessioпs
{
    public class SessionKfc : CartKfc
    {
        public static CartKfc GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionKfc cart = session?.GetJson<SessionKfc>("CartKfc") ?? new SessionKfc();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Kfc kfc, int quantity)
        {
            base.AddItem(kfc, quantity);
            Session.SetJson("CartKfc", this);
        }

        public override void RemoveLine(Kfc kfc)
        {
            base.RemoveLine(kfc);
            Session.SetJson("CartKfc", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("CartKfc");
        }
    }
}
