using AutoMapper;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseApiController
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public CommentController(IMapper mapper)
        {
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = unitOfWork.commentManager.GetList();
            return Ok(values);

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            Comment entity = new Comment();
            try
            {

                entity = unitOfWork.commentManager.GetById(id);
                var model = _mapper.Map<SelectCommentDTO>(entity);
                return Ok(model);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentDTO model)
        {
            try
            {
                var entity = _mapper.Map<Comment>(model);

                unitOfWork.commentManager.Insert(entity);
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
            Comment entity = new Comment();
            try
            {

                entity = unitOfWork.commentManager.GetById(id);
                unitOfWork.commentManager.Delete(entity);
                return Ok();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
    }
}
