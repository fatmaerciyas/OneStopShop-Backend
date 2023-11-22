using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.MessageDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneStopShop.Constants;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseApiController
    {

        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // Route -> Create a new message to send to another user
        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> CreateNewMessage([FromBody] CreateMessageDTO createMessageDto)
        {
            var result = await _messageService.CreateNewMessageAsync(User, createMessageDto);
            if (result.IsSucceed)
                return Ok(result.Message);

            return StatusCode(result.StatusCode, result.Message);
        }

        // Route -> Get All Messages for current user, Either as Sender or as Receiver
        [HttpGet]
        [Route("mine")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SelectMessageDTO>>> GetMyMessages()
        {
            var messages = await _messageService.GetMyMessagesAsync(User);
            return Ok(messages);
        }

        // Route -> Get all messages With Owner access and Admin access
        [HttpGet]
        [Authorize(Roles = StaticUserRoles.OwnerAdmin)]
        public async Task<ActionResult<IEnumerable<SelectMessageDTO>>> GetMessages()
        {
            var messages = await _messageService.GetMessagesAsync();
            return Ok(messages);
        }

        //UnitOfWork unitOfWork = new UnitOfWork();
        //private readonly IMapper _mapper;

        //public MessageController(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}



        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var values = unitOfWork.messageManager.GetList();
        //    return Ok(values);

        //}

        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    Message entity = new Message();
        //    try
        //    {

        //        entity = unitOfWork.messageManager.GetById(id);
        //        var model = _mapper.Map<SelectMessageDTO>(entity);
        //        return Ok(model);
        //    }
        //    catch (Exception e)
        //    {
        //        return NoContent();
        //    }

        //}


        //[HttpPost]
        //public async Task<IActionResult> Add(CreateMessageDTO model)
        //{
        //    try
        //    {
        //        var entity = _mapper.Map<Message>(model);

        //        unitOfWork.messageManager.Insert(entity);
        //        unitOfWork.Complete();
        //        unitOfWork.Dispose();
        //        return Ok(model);
        //    }
        //    catch (Exception e)
        //    {
        //        return NoContent();
        //    }

        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    Message entity = new Message();
        //    try
        //    {

        //        entity = unitOfWork.messageManager.GetById(id);
        //        unitOfWork.messageManager.Delete(entity);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return NoContent();
        //    }
        //}
    }
}
