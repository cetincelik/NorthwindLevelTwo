using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.DomainModels
{
    public class Cart:IDomainModel
    {
        public Cart()
        {
            CartLines=new List<CartLine>();
        }

        public List<CartLine> CartLines { get; set; }

       

    }
}
