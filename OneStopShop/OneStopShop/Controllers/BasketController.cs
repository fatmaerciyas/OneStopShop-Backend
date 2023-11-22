using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;
        private readonly Context _contex;


        public BasketController(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _contex = context;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var basket = unitOfWork.basketManager.GetList();

            if (basket != null)
            {
                return Ok(basket);

            }

            return BadRequest();

        }



        [HttpPost]
        public async Task Add(string userName)
        {
            using (var _context = new Context())
            {
               // var item = _context.Carts.FirstOrDefault(cart => cart.ProductId == productId);


                Basket entity = new Basket();

                if (userName != null)
                {
                    
                    entity.userName = userName;

                    unitOfWork.basketManager.Insert(entity);

                    unitOfWork.Complete();

                    using (var transaction = new TransactionScope())
                    {
                        foreach (var item in _context.Carts)
                        {
                            if (item.BasketId == null)
                            {
                                item.BasketId = entity.BasketId;
                                unitOfWork.cartManager.Update(item);
                            }
                        }

                        unitOfWork.Complete();
                        transaction.Complete();
                    }
                   

                }


            }

        }


    }
}
