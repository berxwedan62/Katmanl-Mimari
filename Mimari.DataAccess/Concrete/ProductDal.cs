using Mimari.Ado.Concrete;
using Mimari.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari.DataAccess.Concrete
{
    public class ProductDal : IEntityRepository<Product>,IProductDal
    {
        public DataSet GetAllDataSet()
        {
            using (MimariContext mimariContext = new MimariContext())
            {
                string sorgu = "Select * from Product";
                return mimariContext.ExecDataReaderProc(sorgu);

            }
        }

        public List<Product> GetAllList()
        {
            List<Product> _products = new List<Product>();
            using (MimariContext mimariContext = new MimariContext())
            {
                string sorgu = "Select * from Product";
                var ds = mimariContext.ExecDataReaderProc(sorgu);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    _products.Add(new Product {
                        ProductId = Convert.ToInt32(item["id"]),
                        ProductName = Convert.ToString(item["ProductName"]),
                        UnitPrice = Convert.ToInt32(item["UnitPrice"]),
                        UnitsInStock = Convert.ToInt32(item["UnitInStock"]),
                        QuantityPerUnit=Convert.ToString(item["QuantityPerUnit"])

                    });
                }
                return _products;

            }
        }

        public Product GetId(int id)
        {

            using (MimariContext mimariContext = new MimariContext())
            {
                Product product=null;
                string sorgu = "Select * From Product Where id=@id";
                Dictionary<string, object> dictList = new Dictionary<string, object>();
                dictList.Add("@id", id);
                var ds = mimariContext.ExecDataReaderProc(sorgu,dictList);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    product = new Product {
                        ProductId = Convert.ToInt32(item["id"]),
                        ProductName = Convert.ToString(item["ProductName"]),
                        UnitPrice = Convert.ToInt32(item["UnitPrice"]),
                        UnitsInStock = Convert.ToInt32(item["UnitInStock"]),
                        QuantityPerUnit = Convert.ToString(item["QuantityPerUnit"])

                    };
                }
                return product;
            }

        }


        public void Add(Product product)
        {
            using (MimariContext mimariContext = new MimariContext())
            {
                string sorgu = "Insert Into Product (ProductName,UnitPrice,QuantityPerUnit) Values (@ProductName,@UnitPrice,@QuantityPerUnit)";
                Dictionary<string, object> dictList = new Dictionary<string, object>();
                dictList.Add("@ProductName", product.ProductName);
                dictList.Add("@UnitPrice", product.UnitPrice);
                dictList.Add("@QuantityPerUnit", product.UnitsInStock);
                mimariContext.ExecNonQueryProc(sorgu, dictList);
            }
        }

        public void Update(Product product)
        {
            using (MimariContext mimariContext = new MimariContext())
            {
                string sorgu = "Update Product SET ProductName=@ProductName,UnitPrice=@UnitPrice,QuantityPerUnit=@QuantityPerUnit WHERE id=@id";
                Dictionary<string, object> dictList = new Dictionary<string, object>();
                dictList.Add("@ProductName", product.ProductName);
                dictList.Add("@UnitPrice", product.UnitPrice);
                dictList.Add("@QuantityPerUnit", product.UnitsInStock);
                dictList.Add("@id", product.ProductId);
                mimariContext.ExecNonQueryProc(sorgu, dictList);

            }
        }


        public void Delete(Product product)
        {

        }

    }
}
