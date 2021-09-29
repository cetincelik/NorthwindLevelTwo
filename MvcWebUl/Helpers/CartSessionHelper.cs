using Entities.DomainModels;
using Microsoft.AspNetCore.Http;
using MvcWebUl.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUl.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
        IHttpContextAccessor _httpContextAccessor;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public Cart GetCart(string key)
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
            if (cartToCheck == null)
            {
                SetCart(key,new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
            }
            return cartToCheck;
        }

        public Cart GetCart()
        {
            throw new NotImplementedException();
        }

        public void SetCart(string key,Cart cart)
        {
           _httpContextAccessor.HttpContext.Session.SetObject(key, cart);
        }

        public void SetCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
