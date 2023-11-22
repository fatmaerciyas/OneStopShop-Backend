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
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;

        public BasketManager(IBasketDal BasketDal)
        {
            _basketDal = BasketDal;
        }

        public void Delete(Basket Basket)
        {
            _basketDal.Delete(Basket);
        }

        public Basket GetById(int Id)
        {
            return _basketDal.GetByID(Id);
        }


        public List<Basket> GetList()
        {
            return _basketDal.List();
        }

        //public List<Basket> GetBasketRelationship()
        //{
        //    return _basketDal.GetBasketRelationship();
        //}

        public Basket GetByUserName(string username)
        {
            return _basketDal.GetBasketByUserName(username);
        }
        public void Insert(Basket Basket)
        {
            _basketDal.Insert(Basket);
        }

        public void Update(Basket Basket)
        {
            _basketDal.Update(Basket);
        }
    }
}
