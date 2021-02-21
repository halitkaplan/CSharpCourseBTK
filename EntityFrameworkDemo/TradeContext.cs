using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class TradeContext:DbContext
    {
        public DbSet<Product> Products { get; set; }  // Benim bir product'ım var ve bunu tablo gibi products ismiyle kullanacağım.
   
            // bunu yaptıktan sonra da kodumuzu yazabiliriz.
            // form kısmına gidip form nesnesine gerekli kodları oraya yazalım

            
        
    }
}
