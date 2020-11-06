using DelClub.Infrastructure;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Sessioпs
{
    public class SessionDominoPizza : CartDominoPizza
    {
        public static CartDominoPizza GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionDominoPizza cart = session?.GetJson<SessionDominoPizza>("CartDominoPizza") ?? new SessionDominoPizza();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(DominoPizza dominoPizza, int quantity)
        {
            base.AddItem(dominoPizza, quantity);
            Session.SetJson("CartDominoPizza", this);
        }

        public override void RemoveLine(DominoPizza dominoPizza)
        {
            base.RemoveLine(dominoPizza);
            Session.SetJson("CartDominoPizza", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("CartDominoPizza");
        }
    }
}
