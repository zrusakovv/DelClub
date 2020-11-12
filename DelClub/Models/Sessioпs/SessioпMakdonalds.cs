using DelClub.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace DelClub.Models.Sessioпs
{
    public class SessioпMakdonalds : CartMakdonalds
    {
        public static CartMakdonalds GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessioпMakdonalds cart = session?.GetJson<SessioпMakdonalds>("Makdonalds") ?? new SessioпMakdonalds();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Makdonalds makdonalds, int quantity)
        {
            base.AddItem(makdonalds, quantity);
            Session.SetJson("Makdonalds", this);
        }

        public override void RemoveLine(Makdonalds makdonalds)
        {
            base.RemoveLine(makdonalds);
            Session.SetJson("Makdonalds", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Makdonalds");
        }
    }
}
