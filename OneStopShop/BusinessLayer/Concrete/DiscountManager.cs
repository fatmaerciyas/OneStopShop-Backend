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
    public class DiscountManager : IDiscountService
    {
        IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal DiscountDal)
        {
            _discountDal = DiscountDal;
        }

        public void Delete(Discount Discount)
        {
            _discountDal.Delete(Discount);
        }

        public Discount GetById(int Id)
        {
            return _discountDal.GetByID(Id);
        }

        public List<Discount> GetList()
        {
            return _discountDal.List();
        }

        public void Insert(Discount Discount)
        {
            _discountDal.Insert(Discount);
        }

        public void Update(Discount Discount)
        {
            _discountDal.Update(Discount);
        }
    }
}
