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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal NotificationDal)
        {
            _notificationDal = NotificationDal;
        }

        public void Delete(Notification Notification)
        {
            _notificationDal.Delete(Notification);
        }

        public Notification GetById(int Id)
        {
            return _notificationDal.GetByID(Id);
        }

        public List<Notification> GetList()
        {
            return _notificationDal.List();
        }

        public void Insert(Notification Notification)
        {
            _notificationDal.Insert(Notification);
        }

        public void Update(Notification Notification)
        {
            _notificationDal.Update(Notification);
        }
    }
}
