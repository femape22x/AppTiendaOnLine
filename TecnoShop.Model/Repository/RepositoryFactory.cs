using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoShop.Model.Repository
{
    public class RepositoryFactory
    {
        public static IUserRepository GetUserRepository()
        {
            return new TecnoShop.Model.Repository.Impl.UserRepository();
        }
        public static IProductRepository GetProductRepository()
        {
            return new TecnoShop.Model.Repository.Impl.ProductRepository();
        }
    }
}
