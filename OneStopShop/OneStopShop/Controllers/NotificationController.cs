using AutoMapper;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.NotificatonDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseApiController
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public NotificationController(IMapper mapper)
        {
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = unitOfWork.notificationManager.GetList();
            return Ok(values);

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            Notification entity = new Notification();
            try
            {

                entity = unitOfWork.notificationManager.GetById(id);
                var model = _mapper.Map<SelectNotificationDTO>(entity);
                return Ok(model);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateNotificationDTO model)
        {
            try
            {
                var entity = _mapper.Map<Notification>(model);

                unitOfWork.notificationManager.Insert(entity);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return Ok(model);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Notification entity = new Notification();
            try
            {

                entity = unitOfWork.notificationManager.GetById(id);
                unitOfWork.notificationManager.Delete(entity);
                return Ok();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
    }
}
