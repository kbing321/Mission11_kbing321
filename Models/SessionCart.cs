using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_kbing321.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission09_kbing321.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        private static T GetJson<T>(string v)
        {
            throw new NotImplementedException();
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddBook(Book book, int qty)
        {
            base.AddBook(book, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveBook(Book book)
        {
            base.RemoveBook(book);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }


    }
}
