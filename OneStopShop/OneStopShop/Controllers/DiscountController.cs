using AutoMapper;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.DiscountDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : BaseApiController
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public DiscountController(IMapper mapper)
        {
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = unitOfWork.discountManager.GetList();
            return Ok(values);

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            Discount entity = new Discount();
            try
            {

                entity = unitOfWork.discountManager.GetById(id);
                var model = _mapper.Map<SelectDiscountDTO>(entity);
                return Ok(model);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateDiscountDTO model)
        {
            try
            {
                var entity = _mapper.Map<Discount>(model);

                unitOfWork.discountManager.Insert(entity);
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
            Discount entity = new Discount();
            try
            {

                entity = unitOfWork.discountManager.GetById(id);
                unitOfWork.discountManager.Delete(entity);
                return Ok();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
    }
}
