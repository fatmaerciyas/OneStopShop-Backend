using AutoMapper;
using DTOLayer.DTOs.AuthDTOs;
using DTOLayer.DTOs.CartDTOs;
using DTOLayer.DTOs.CartItemDTOs;
using DTOLayer.DTOs.CategoryDTOs;
using DTOLayer.DTOs.CommentDTOs;
using DTOLayer.DTOs.DiscountDTOs;
using DTOLayer.DTOs.MessageDTOs;
using DTOLayer.DTOs.NotificatonDTOs;
using DTOLayer.DTOs.OrderDTOs;
using DTOLayer.DTOs.ProductDTOs;
using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;

namespace OneStopShop.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
       

            //CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            //CreateMap<Category, SelectCategoryDTO>().ReverseMap();
            //CreateMap<Category, UpdateCategoryDTO>().ReverseMap();


            //CreateMap<Cart, CreateCartDTO>().ReverseMap();
            //CreateMap<Cart, SelectCartDTO>().ReverseMap();
            //CreateMap<Cart, UpdateCartDTO>().ReverseMap();

            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Comment, SelectCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap();

            CreateMap<Discount, CreateDiscountDTO>().ReverseMap();
            CreateMap<Discount, SelectDiscountDTO>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDTO>().ReverseMap();

            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, SelectMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();

            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();
            CreateMap<Notification, SelectNotificationDTO>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDTO>().ReverseMap();

            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, SelectOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, SelectProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

         
            CreateMap<ApplicationUser, UserInfoResult>().ReverseMap();
        }
    }
}
