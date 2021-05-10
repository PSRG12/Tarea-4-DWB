using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_DWB.BackEnd
{
    public class ProductSC : BaseSC
    {
        public void AddNewProduct(string productname,decimal price)
        {
            var newProduct = new NorthwindData.Product();

            newProduct.ProductName = productname;
            newProduct.UnitPrice = price;

            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();
        }
       
    }
}
