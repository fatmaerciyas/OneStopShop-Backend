using AutoMapper;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.CategoryDTOs;
using DTOLayer.DTOs.ProductDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private async Task<IActionResult> GetAll()
        {
            var values = unitOfWork.productManager.GetList();
            return Ok(values);

        }


        private async Task<IActionResult> GetById(int id)
        {
            Product entity = new Product();
            try
            {

                entity = unitOfWork.productManager.GetById(id);
                if (entity == null) return NotFound();

                var model = _mapper.Map<SelectProductDTO>(entity);
                return Ok(model);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }


        private async Task<IActionResult> GetProductByCategoryId(int id)
        {
            List<Product> entity = new List<Product>();
            try
            {
                entity = unitOfWork.productManager.GetProductsByCategoryId(id);

                //var model = _mapper.Map<SelectProductDTO>(entity);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] int? id, [FromQuery] int? categoryId)
        {
            if (id.HasValue)
            {
                return await GetById(id.Value);
            }
            else if (categoryId.HasValue)
            {
               return await GetProductByCategoryId(categoryId.Value);
            }
            else if(id == null && categoryId==null)
            {
                return await GetProductByCategoryId(1);
            }

            else { return BadRequest(); }
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductDTO model)
        {
            try
            {
                var entity = _mapper.Map<Product>(model);

                unitOfWork.productManager.Insert(entity);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return Ok(model);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }

        [HttpPut]
        public async Task<IActionResult> Edit(UpdateProductDTO model,int id)
        {
            try
            {
                var entity = unitOfWork.productManager.GetById(id);

                model.ProductId = entity.ProductId;

                if(entity.ProductId == model.ProductId)
                {
                    entity = _mapper.Map<UpdateProductDTO, Product>(model); 
                }
               

                unitOfWork.productManager.Update(entity);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return Ok(model);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product entity = new Product();
            try
            {

                entity = unitOfWork.productManager.GetById(id);
                unitOfWork.productManager.Delete(entity);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return Ok();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }



    }
}
