using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BouquetMvc.Models;
using BouquetEngine.Model;


namespace BouquetMvc.Servises
{
    public class SessionCartStorage
    {
        public void AddToSessionCart(ISession session, Bouquet bouquet)
        {
            var sessionCart = session.GetObjectFromJson<CartViewModel>("cart");
            if (sessionCart == null)
            {
                sessionCart = new CartViewModel();
            }
            sessionCart.items.Add(bouquet);
            session.SetObjectAsJson("cart", sessionCart);
        }

        public CartViewModel GetCartFromSession(ISession session)
        {
            CartViewModel sessionCart = session.GetObjectFromJson<CartViewModel>("cart");
            if (sessionCart == null)
            {
                sessionCart = new CartViewModel();
                session.SetObjectAsJson("cart", sessionCart);
            }
            return sessionCart;
        }

        public void RemoveItemFromSessionCart(ISession session, Bouquet bouquet)
        {
            CartViewModel sessionCart = this.GetCartFromSession(session);
            sessionCart.items.Remove(bouquet);
            session.SetObjectAsJson("cart", sessionCart);
        }
    }
}