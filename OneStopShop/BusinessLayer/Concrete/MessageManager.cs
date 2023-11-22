using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs.GeneralIdentityResponseDTO;
using DTOLayer.DTOs.MessageDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        private readonly Context _context;
        private readonly ILogService _logService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageManager(Context context, ILogService logService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logService = logService;
            _userManager = userManager;
        }

        public async Task<GeneralIdentityDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDTO createMessageDto)
        {
            if (User.Identity.Name == createMessageDto.Receiver)
                return new GeneralIdentityDto()
                {
                    IsSucceed = false,
                    StatusCode = 400,
                    Message = "Sender and Receiver can not be same",
                };

            var isReceiverUserNameValid = _userManager.Users.Any(q => q.UserName == createMessageDto.Receiver);
            if (!isReceiverUserNameValid)
                return new GeneralIdentityDto()
                {
                    IsSucceed = false,
                    StatusCode = 400,
                    Message = "Receiver UserName is not valid",
                };

            Message newMessage = new Message()
            {
                Sender = User.Identity.Name,
                Receiver = createMessageDto.Receiver,
                Subject = createMessageDto.Subject,
                Details = createMessageDto.Details,
            };
            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            await _logService.SaveNewLog(User.Identity.Name, "Send Message");

            return new GeneralIdentityDto()
            {
                IsSucceed = true,
                StatusCode = 201,
                Message = "Message saved successfully",
            };
        }

        public async Task<IEnumerable<SelectMessageDTO>> GetMessagesAsync()
        {
            var messages =  _context.Messages
                .Select(q => new SelectMessageDTO()
                {
                    MessageId = q.Id,
                    Sender= q.Sender,
                    Receiver = q.Receiver,
                    Subject = q.Subject,
                    Details = q.Details,
                    CreatedAt = q.CreatedAt
                })
                .OrderByDescending(q => q.CreatedAt)
                .ToList();

            return messages;
        }

        public async Task<IEnumerable<SelectMessageDTO>> GetMyMessagesAsync(ClaimsPrincipal User)
        {
            var loggedInUser = User.Identity.Name;

            var messages =  _context.Messages
                .Where(q => q.Sender == loggedInUser || q.Receiver == loggedInUser)
             .Select(q => new SelectMessageDTO()
             {
                 MessageId = q.Id,
                 Sender = q.Sender,
                 Receiver = q.Receiver,
                 Subject = q.Subject,
                 Details = q.Details,
                 CreatedAt = q.CreatedAt
             })
             .OrderByDescending(q => q.CreatedAt)
             .ToList();

            return messages;
        }
        public MessageManager(IMessageDal MessageDal)
        {
            _messageDal = MessageDal;
        }

        public void Delete(Message Message)
        {
            _messageDal.Delete(Message);
        }

        public Message GetById(int Id)
        {
            return _messageDal.GetByID(Id);
        }

        public List<Message> GetList()
        {
            return _messageDal.List();
        }

        public void Insert(Message Message)
        {
            _messageDal.Insert(Message);
        }

        public void Update(Message Message)
        {
            _messageDal.Update(Message);
        }
    }
}
