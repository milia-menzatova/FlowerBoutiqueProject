using System.Collections.Generic;
using BouquetEngine.Model;
using System.Linq;
using System.Security.AccessControl;


namespace BouquetMvc.Models
{
    public class CartViewModel
    {
        public List<Bouquet> items { get; set; }

        //constractor
        public CartViewModel()
        {
            this.items = new List<Bouquet>();
        }
        //Methods
        public int Size()
        {
            return this.items.Count;
        }
        public bool IsEmpty()
        {
            return this.Size() == 0;
        }
        public double GetTotalPrice()
        {
            double total = 0d;
            foreach (var bouquet in this.items)
            {
                total = total + bouquet.Price;
            }
            return total;
        }



    }
}