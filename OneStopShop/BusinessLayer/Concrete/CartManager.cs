using Azure;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;

        }

        //public void Delete(int productId, int quantity )
        //{
        //    _cartDal.Delete(Cart);
        //}

        public void Delete(Cart t)
        {
            throw new NotImplementedException();
        }

        public Cart GetById(int Id)
        {
            return _cartDal.GetByID(Id);
        }

        public List<Cart> GetList()
        {
            return _cartDal.List();
        }

        public void Insert(Cart t)
        {
             _cartDal.Insert(t);
        }

        public List<Cart> GetCartProductRelationship()
        {
            return _cartDal.GetCartProductRelationship();
        }


        public void Update(Cart Cart)
        {
            _cartDal.Update(Cart);
        }



    }
}
