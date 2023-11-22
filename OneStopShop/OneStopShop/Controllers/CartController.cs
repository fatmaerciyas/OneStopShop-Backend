using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs.AuthDTOs;
using DTOLayer.DTOs.CartDTOs;
using DTOLayer.DTOs.CartItemDTOs;
using DTOLayer.DTOs.CategoryDTOs;
using DTOLayer.DTOs.ProductDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OneStopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseApiController
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;
        private readonly Context _contex;
        private readonly IAuthService _authService;


        public CartController(IMapper mapper, Context context, IAuthService authService)
        {
            _mapper = mapper;
            _contex = context;
            _authService = authService;
        }




        //private async Task<ActionResult> GetCartByUserId()
        //{

        //    var values = unitOfWork.productManager.GetList();

        //    if (values != null)
        //    {
        //        return Ok();
        //    }
        //    return Ok();


        //    var cart = await _contex.Carts
        //        .Include(i => i.Items)
        //        .ThenInclude(p => p.Product)
        //    .FirstOrDefaultAsync(x => x.BuyerId == "1");
        //    Request.Cookies["buyerId"

        //    if (cart == null) kjkj
        //    { return NotFound(); }
        //    else
        //    {
        //        return MapCartToDto(cart);
        //    }


        //}

        //private static ActionResult<CreateCartDTO> MapCartToDto(Cart cart)
        //{
        //    return new CreateCartDTO
        //    {
        //        Id = cart.CartId,
        //        BuyerId = cart.BuyerId,
        //        Items = cart.Items.Select(item => new CartItemDTO
        //        {
        //            ProductId = item.ProductId,
        //            Name = item.Product.Name,
        //            Price = item.Product.Price,
        //            Image = item.Product.Image,
        //            Brand = item.Product.Brand,
        //            Quantity = item.Quantity,
        //        }).ToList()
        //    };
        //}


        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    Cart entity = new Cart();
        //    try
        //    {

        //        entity = unitOfWork.cartManager.GetById(id);
        //        var model = _mapper.Map<SelectCartDTO>(entity);
        //        return Ok(model);
        //    }
        //    catch (Exception e)
        //    {
        //        return NoContent();
        //    }

        //}

        //[HttpPost]
        //public async Task<ActionResult<CreateCartDTO>> AddItemToCart(int productId, int quantity)
        //{
        //    //if that use don't have a cart, create one 
        //    //but if they have , just add to cart
        //    //control this when authentication

        //    //now nobody has a cart then I'm going to create cart




        //    using (var _context = new Context())
        //    {

        //        var cart = await _contex.Carts

        //    .FirstOrDefaultAsync(x => x.BuyerId == "1");
        //        Request.Cookies["buyerId"]

        //        if (cart == null) cart = CreateCart();

        //        var product = await _contex.Products.FindAsync(productId);

        //        if (product == null) return NotFound();


        //        AddItem(product, quantity, cart.CartId);

        //        return Ok();

        //        var result = await _contex.SaveChangesAsync() > 0;

        //        if (result) return Ok(result);
        //        return BadRequest(new ProblemDetails { Title = "Probem saving item to Cart" });
        //    }
        //}


        //[HttpDelete]
        //public async Task<ActionResult> RemoveCartItem(int productId, int quantity)
        //{
        //    var cart = await _contex.Carts
        //        .Include(i => i.Items)
        //        .ThenInclude(p => p.Product)
        //    .FirstOrDefaultAsync(x => x.BuyerId == "1");
        //    Request.Cookies["buyerId"]
        //    if (cart == null) return NotFound();
        //    RemoveItem(productId, quantity);

        //    return Ok();

        //    var result = await _contex.SaveChangesAsync() > 0;
        //    if (result) return Ok();

        //    return BadRequest(new ProblemDetails { Title = "Problem removing item from the cart " });
        //}
        //private async Task<Cart> RetrieveCart()
        //{

        //    using (var _context = new Context())
        //    {
        //        return await _contex.Carts
        //        .Include(i => i.Items)
        //        .ThenInclude(p => p.Product)
        //        .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["BuyerId"]);
        //    }
        //}

        //private Cart CreateCart()
        //{
        //    using (var _context = new Context())
        //    {
        //        get this authenticatio later
        //        var buyerId = Guid.NewGuid().ToString();
        //        var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
        //        Response.Cookies.Append("buyerId", buyerId, cookieOptions);

        //        var cart = new Cart { BuyerId = buyerId };
        //        _contex.Carts.Add(cart);

        //        return cart;
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var cartItems = unitOfWork.cartManager.GetCartProductRelationship();
            List<Cart> cart = new List<Cart>();
            if (cartItems != null)
            {
                foreach (var item in cartItems)
                {
                    if (item.BasketId == null)
                    {
                        cart.Add(item);
                    }
                }
                return Ok(cart);

            }

            return BadRequest();

        }



        [HttpPost]
        public void Add(int productId, int quantity)
        {
            using (var _context = new Context())
            {
                var items = _context.Carts.Where(cart => cart.ProductId == productId).ToList();


                foreach (var item in items)
                {
                    if ( item.BasketId == null)
                    {


                        item.Quantity += quantity;
                        unitOfWork.cartManager.Update(item);
                        unitOfWork.Complete();
                        unitOfWork.Dispose();

                    }

                }
                unitOfWork.cartManager.Insert(new Cart { ProductId = productId, Quantity = quantity });
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }

        }

        [HttpDelete]
        public void RemoveItem(int productId, int quantity)
        {
            using (var _context = new Context())
            {
                var items = _context.Carts.Where(cart => cart.ProductId == productId).ToList();

                foreach (var item in items)
                {

                    if (item.BasketId == null)
                    {

                        if (item.Quantity == 0)
                        {
                            unitOfWork.cartManager.Delete(item);
                            unitOfWork.Complete();
                            unitOfWork.Dispose();
                        }

                        else
                        {
                            item.Quantity -= quantity;
                            unitOfWork.cartManager.Update(item);
                            unitOfWork.Complete();
                            unitOfWork.Dispose();
                        }

                    }
                }

            }
        }




        //[HttpPost]
        //public async Task<IActionResult> Add(CreateCartDTO model)
        //{
        //    try
        //    {
        //        var entity = _mapper.Map<Cart>(model);

        //        unitOfWork.cartManager.Insert(entity);
        //        unitOfWork.Complete();
        //        unitOfWork.Dispose();
        //        return Ok(model);
        //    }
        //    catch (Exception e)
        //    {
        //        return NoContent();
        //    }

        //}

        //[Route("{id}")] //look
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    Cart entity = new Cart();
        //    try
        //    {

        //        entity = unitOfWork.cartManager.GetById(id);
        //        unitOfWork.cartManager.Delete(entity);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return NoContent();
        //    }
        //}
    }
}
