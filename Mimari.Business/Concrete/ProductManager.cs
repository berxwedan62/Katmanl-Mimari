using Mimari.Ado.Concrete;
using Mimari.Business.Abstract;
using Mimari.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        private Product products;
        public  ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public List<Product> GetAllList()
        {
            return _productDal.GetAllList();
        }

        public Product GetId(int id)
        {
            return _productDal.GetId(id);
        }

        public void Update()
        {
            _productDal.Update(products);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
