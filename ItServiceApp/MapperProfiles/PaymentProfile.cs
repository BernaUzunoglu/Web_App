using AutoMapper;
using ItServiceApp.Models;
using ItServiceApp.Models.Payment;
using Iyzipay.Model;

namespace ItServiceApp.MapperProfiles
{
    public class PaymentProfile:Profile// mapper işlemi gerçekleştirmek için mapleme(eşleme) oluşturma
    {
        public PaymentProfile()
        {
            //Yazdığımız modellerin kullanmamız için gereken modellere eşlenmesi(Iyzipay deki modellere) *MAPPER* one object type to another object type*
            CreateMap<CardModel, PaymentCard>().ReverseMap();
            CreateMap<BasketModel, BasketItem>().ReverseMap();
            CreateMap<AddressModel, Address>().ReverseMap();
            CreateMap<CustomerModel, Buyer>().ReverseMap();
            CreateMap<InstallmentPriceModel, InstallmentPrice>().ReverseMap();
            CreateMap<InstallmentModel, InstallmentDetail>().ReverseMap();
            CreateMap<PaymentResponseModel, Payment>().ReverseMap();

        }
    }
}
