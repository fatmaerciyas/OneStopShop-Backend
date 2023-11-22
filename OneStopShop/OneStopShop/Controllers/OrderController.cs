//using AutoMapper;
//using BusinessLayer.Abstract;
//using BusinessLayer.Concrete;
//using DTOLayer.DTOs.OrderDTOs;
//using EntityLayer.Concrete;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace OneStopShop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderController : BaseApiController
//    {
//        private readonly IAuthService _authService;


//        UnitOfWork unitOfWork = new UnitOfWork();
//        private readonly IMapper _mapper;

//        public OrderController(IMapper mapper, IAuthService authService)
//        {
//            _mapper = mapper;
//            _authService = authService;
//        }



     
//        private async Task<IActionResult> GetAll()
//        {
//            var values = unitOfWork.orderManager.GetOrderRelationships();
//            return Ok(values);

//        }

//        [HttpGet]
//        public async Task<IActionResult> GetProduct([FromQuery] string? username)
//        {
//            if (username != null)
//            {
//                return await GetById(username);
//            }
 
//            else
//            {
//                return await GetAll();
//            }
//        }

      
//        private async Task<IActionResult> GetById(string username)
//        {
//            Order entity = new Order();
//            try
//            {

//                entity = unitOfWork.orderManager.GetOrderByUserName(username);
               
//                return Ok(entity);
//            }
//            catch (Exception e)
//            {
//                return NoContent();
//            }

//        }


//        [HttpPost]
//        public async Task<IActionResult> Add(int basketId, string userName)
//        {
//            try
//            {
//                var entity = new Order();

//                var user = await _authService.GetUserDetailsByUserNameAsync(userName);

//                entity.BasketId = basketId;
//                entity.UserName = user.UserName;

//                unitOfWork.orderManager.Insert(entity);

//                unitOfWork.Complete();
//                unitOfWork.Dispose();
//                return Ok(entity);
//            }
//            catch (Exception e)
//            {
//                return NoContent();
//            }

//        }

//        [HttpDelete]
//        public async Task<IActionResult> Delete(int id)
//        {
//            Order entity = new Order();
//            try
//            {

//                entity = unitOfWork.orderManager.GetById(id);
//                unitOfWork.orderManager.Delete(entity);
//                return Ok();
//            }
//            catch (Exception e)
//            {
//                return NoContent();
//            }
//        }
//    }
//}
