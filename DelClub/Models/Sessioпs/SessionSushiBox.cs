using DelClub.Infrastructure;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace DelClub.Models.Sessioпs
{
    public class SessionSushiBox : CartSushiBox
    {
        public static CartSushiBox GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionSushiBox cart = session?.GetJson<SessionSushiBox>("CartSushiBox") ?? new SessionSushiBox();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(SushiBox sushiBox, int quantity)
        {
            base.AddItem(sushiBox, quantity);
            Session.SetJson("CartSushiBox", this);
        }

        public override void RemoveLine(SushiBox sushiBox)
        {
            base.RemoveLine(sushiBox);
            Session.SetJson("CartSushiBox", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("CartSushiBox");
        }
    }
}
