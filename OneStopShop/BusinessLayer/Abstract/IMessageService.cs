using DTOLayer.DTOs.GeneralIdentityResponseDTO;
using DTOLayer.DTOs.MessageDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task<GeneralIdentityDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDTO createMessageDto);
        Task<IEnumerable<SelectMessageDTO>> GetMessagesAsync();
        Task<IEnumerable<SelectMessageDTO>> GetMyMessagesAsync(ClaimsPrincipal User);
    }
}
