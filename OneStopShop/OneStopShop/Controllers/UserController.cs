using AutoMapper;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OneStopShop.Controllers
{
//    [Route("api/[controller]")]
//    [ApiController]
    //public class UserController : BaseApiController
    //{

    //    UnitOfWork unitOfWork = new UnitOfWork();
    //    private readonly IMapper _mapper;

    //    public UserController(IMapper mapper)
    //    {
    //        _mapper = mapper;
    //    }



    //    [HttpGet]
    //    public async Task<IActionResult> GetAll()
    //    {
    //        var values = unitOfWork.userManager.GetList();
    //        return Ok(values);

    //    }

    //    [Route("{id}")]
    //    [HttpGet]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        User entity = new User();
    //        try
    //        {

    //            entity = unitOfWork.userManager.GetById(id);
    //            var model = _mapper.Map<SelectUserDTO>(entity);
    //            return Ok(model);
    //        }
    //        catch (Exception e)
    //        {
    //            return NoContent();
    //        }

    //    }


    //    [HttpPost]
    //    public async Task<IActionResult> Add(CreateUserDTO model)
    //    {
    //        try
    //        {
    //            var entity = _mapper.Map<User>(model);

    //            unitOfWork.userManager.Insert(entity);
    //            unitOfWork.Complete();
    //            unitOfWork.Dispose();
    //            return Ok(model);
    //        }
    //        catch (Exception e)
    //        {
    //            return NoContent();
    //        }

    //    }

    //    [HttpDelete]
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        User entity = new User();
    //        try
    //        {

    //            entity = unitOfWork.userManager.GetById(id);
    //            unitOfWork.userManager.Delete(entity);
    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return NoContent();
    //        }
    //    }
    //}
}
