using AutoMapper;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.CategoryDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = unitOfWork.categoryManager.GetList();
            return Ok(values);

        }
     


        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDTO model)
        {
            try
            {
                var entity = _mapper.Map<Category>(model);

                unitOfWork.categoryManager.Insert(entity);
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
            Category entity = new Category();
            try
            {

                entity = unitOfWork.categoryManager.GetById(id);
                unitOfWork.categoryManager.Delete(entity);
                return Ok();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
    }
}

