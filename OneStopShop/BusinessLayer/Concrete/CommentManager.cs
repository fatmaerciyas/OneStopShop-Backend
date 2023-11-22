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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal CommentDal)
        {
            _commentDal = CommentDal;
        }

        public void Delete(Comment Comment)
        {
            _commentDal.Delete(Comment);
        }

        public Comment GetById(int Id)
        {
            return _commentDal.GetByID(Id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public void Insert(Comment Comment)
        {
            _commentDal.Insert(Comment);
        }

        public void Update(Comment Comment)
        {
            _commentDal.Update(Comment);
        }
    }
}
