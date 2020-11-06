using DelClub.Infrastructure;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace DelClub.Models.Sessioпs
{
    public class SessionMyBox : CartMyBox
    {
        public static CartMyBox GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionMyBox cart = session?.GetJson<SessionMyBox>("CartMyBox") ?? new SessionMyBox();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(MyBox myBox, int quantity)
        {
            base.AddItem(myBox, quantity);
            Session.SetJson("CartMyBox", this);
        }

        public override void RemoveLine(MyBox myBox)
        {
            base.RemoveLine(myBox);
            Session.SetJson("CartMyBox", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("CartMyBox");
        }
    }
}
