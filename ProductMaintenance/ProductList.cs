using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaintenance
{
    public class ProductList
    {
        //fields
        private List<Product> products;

        public delegate void ChangeHandler(ProductList products);//type definition  of a reference to a method
        public event ChangeHandler Changed;  

        /// <summary>
        /// The constructor creates/instatntiates a List object to
        /// store information of products in the inventory
        /// </summary>
        
        public ProductList()
        {
            products = new List<Product>();
        }

        public int Count => products.Count;

        //indexer

        public Product this[int  i]
        {
            get
            {
                if ((i < 0) || (i >= products.Count))
                    throw new ArgumentOutOfRangeException("Product does not exist at position " + (i + 1));
                return products[i];
            }
            set
            {
                products[i] = value;
                Changed(this);
            }
        }




    }
}
