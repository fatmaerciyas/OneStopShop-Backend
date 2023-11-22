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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal OrderDal)
        {
            _orderDal = OrderDal;
        }

        public void Delete(Order Order)
        {
            _orderDal.Delete(Order);
        }

        public Order GetById(int Id)
        {
            return _orderDal.GetByID(Id);
        }

        public List<Order> GetList()
        {
            return _orderDal.List();
        }

        public void Insert(Order Order)
        {
            _orderDal.Insert(Order);
        }

        public void Update(Order Order)
        {
            _orderDal.Update(Order);
        }
        //public Order GetOrderByUserName(string username)
        //{
        //    return _orderDal.GetOrderByUserName( username);
        //}
        public List<Order> GetOrderRelationships()
        {
            return _orderDal.GetOrderRelationships();
        }
    }
}
