using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal ProductDal)
        {
            _productDal = ProductDal;
        }

        public void Delete(Product Product)
        {
            _productDal.Delete(Product);
        }

        public Product GetById(int Id)
        {
            return _productDal.GetByID(Id);
        }

        public List<Product> GetList()
        {
            return _productDal.List();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return _productDal.List(x => x.CategoryId == id);
        }

        public void Insert(Product Product)
        {
            _productDal.Insert(Product);
        }

        public void Update(Product Product)
        {
            _productDal.Update(Product);
        }
    }
}
