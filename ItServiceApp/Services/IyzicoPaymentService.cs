using AutoMapper;
using ItServiceApp.Models;
using ItServiceApp.Models.Identity;
using ItServiceApp.Models.Payment;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MUsefulMethods;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ItServiceApp.Services
{
    public class IyzicoPaymentService : IPaymentService
    {

        private readonly IConfiguration _configuration;
        private readonly IyzicoPaymentOptions _options;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;// Buyer için


        public IyzicoPaymentService(IConfiguration configuration, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            var section = configuration.GetSection(IyzicoPaymentOptions.Key);//IyzicoOptionsKey inin alıyor GetSection()Apsetting jsondaki optionsları getiriyor

            _options = new IyzicoPaymentOptions()
            {
                ApiKey = section["ApiKey"],
                SecretKey = section["SecretKey"],
                BaseUrl = section["BaseUrl"],
                ThreadsCallbackUrl = section["ThreadsCallbackUrl"],
            };
            _userManager = userManager;
        }

        private string GenerateConversationId()
        {
            return StringHelpers.GenerateUniqueCode();
        }

        private CreatePaymentRequest InitialPaymentRequest(PaymentModel model)
        {
            //var paymentRequest = new CreatePaymentRequest();
            //paymentRequest.Installment=model.Installment;
            //paymentRequest.Locale=Locale.TR.ToString();
            //paymentRequest.ConversationId=GenerateConversationId();
            //paymentRequest.Price = model.Price.ToString(new CultureInfo("en-US"));
            //paymentRequest.PaidPrice = model.PaidPrice.ToString(new CultureInfo("en-US"));
            //paymentRequest.Currency=Currency.TRY.ToString();
            //paymentRequest.BasketId=StringHelpers.GenerateUniqueCode();
            //paymentRequest.PaymentChannel = PaymentChannel.WEB.ToString();
            //paymentRequest.PaymentGroup = PaymentGroup.SUBSCRIPTION.ToString();
            var paymentRequest = new CreatePaymentRequest
            {
                Installment = model.Installment,
                Locale = Locale.TR.ToString(),
                ConversationId = GenerateConversationId(),
                Price = model.Price.ToString(new CultureInfo("en-US")),
                PaidPrice = model.PaidPrice.ToString(new CultureInfo("en-US")),
                Currency = Currency.TRY.ToString(),
                BasketId = StringHelpers.GenerateUniqueCode(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.SUBSCRIPTION.ToString(),
                PaymentCard= _mapper.Map<PaymentCard>(model.CardModel),
                Buyer = _mapper.Map<Buyer>(model.Customer),
                BillingAddress = _mapper.Map<Address>(model.Adress)
            };


            //paymentRequest.PaymentCard = _mapper.Map<PaymentCard>(model.CardModel);

           // var user=_userManager.FindByIdAsync(model.UserId).Result;
            //var buyer = new Buyer //mapper kullandığımız için gerek klamadı
            //{
            //    Id = user.Id,
            //Name = user.Name,
            //Surname = user.Surname,
            //GsmNumber = user.PhoneNumber,
            //Email = user.Email,
            //IdentityNumber = "11111111110",
            //LastLoginDate = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}",
            //RegistrationDate = $"{user.CreateDate:yyyy-MM-dd HH:mm:ss}",
            //RegistrationAddress = " Cihannuma Mah. Barbaros Bulvarı No:9 Beşiktaş",
            //Ip = model.Ip,
            //City = "Istanbul",
            //Country = "Turkey",
            //ZipCode = "34732",
            ////request.Buyer = buyer

            //};
           // paymentRequest.Buyer = _mapper.Map<Buyer>(model.Customer);

            //Address billingAddress = new Address//fatura adresi
            //{
            //    ContactName = $"{user.Name}{user.Surname}",
            //    City = "Istanbul",
            //    Country = "Turkey",
            //    Description = "Cihannuma Mah. Barbaros Bulvarı No:9 Beşiktaş",
            //    ZipCode = "34742"
            //};
            //paymentRequest.BillingAddress = billingAddress; // aşağıdaki mapper işlemi bu işlemi yapıyor

            //paymentRequest.BillingAddress = _mapper.Map<Address>(model.Adress);

            var basketItems= new List<BasketItem>();
            foreach (var basketModel in model.BasketList)
            {
                basketItems.Add(_mapper.Map<BasketItem>(basketModel));
            }
            paymentRequest.BasketItems = basketItems;
            return paymentRequest;

            //var firstBasketItem = new BasketItem
            //{

            //    Id = "BI101",
            //    Name = "Binocular",
            //    Category1 = "Collectibles",
            //    Category2 = "Acessories",
            //    ItemType = BasketItemType.VIRTUAL.ToString(),
            //    Price = model.Price.ToString(new CultureInfo("en-US"))
            //};

            //basketItems.Add(firstBasketItem);
            //paymentRequest.BasketItems=basketItems;

            //return paymentRequest;

           
        }
        public InstallmentModel CheckInstallments(string binNumber, decimal price)
        {
            var conversationId = GenerateConversationId();
            var request = new RetrieveInstallmentInfoRequest()
            {
                Locale = Locale.TR.ToString(),
                ConversationId = conversationId,
                BinNumber = binNumber.Substring(0,6),
                Price = price.ToString(new CultureInfo("en-US")),
            };

            var result = InstallmentInfo.Retrieve(request, _options);

            if (result.Status=="failure")
            {
                throw new Exception(result.ErrorMessage);
            }

            if (result.ConversationId != conversationId)
            {
                throw new Exception("Hatalı istek oluşturuldu.");
            }
            var resultModel = _mapper.Map<InstallmentModel>(result.InstallmentDetails[0]);


            Console.WriteLine();
            return resultModel;
            //return null;
        }


        public PaymentResponseModel Pay(PaymentModel model)
        {
            var request = this.InitialPaymentRequest(model);
            var payment = Payment.Create(request, _options);

            //paymneti - paymentresponse çevir

            return _mapper.Map<PaymentResponseModel>(payment);
            
        }
    }
}
