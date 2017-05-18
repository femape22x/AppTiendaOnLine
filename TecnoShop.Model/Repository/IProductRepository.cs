using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoShop.Model.Entities;

namespace TecnoShop.Model.Repository
{
    public interface IProductRepository
    {
        List<Product> FindAll();

        void Create(Product product);
    }
}
