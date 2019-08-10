using Mimari.Ado.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllList();
        void Update(Product product);
        void Add(Product product);
        Product GetId(int id);
    }
}
