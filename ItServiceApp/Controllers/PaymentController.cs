using ItServiceApp.Models;
using ItServiceApp.Models.Payment;
using ItServiceApp.Services;
using ItServiceApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ItServiceApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult CheckInstallment( string binNumber)
        {
            if(binNumber.Length != 6) return BadRequest(new
            {
                Message="Bad req."
            });

            var result = _paymentService.CheckInstallments(binNumber, 1000);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(PaymentViewModel model)
        {

            var paymenModel = new PaymentModel()
            {
                Installment = model.Installment,
                Adress = new AddressModel(),
                BasketList = new List<BasketModel>(),
                Customer = new CustomerModel(),
                CardModel = new CardModel(),
                Price = 1000,
            };
            
            return View(model);
        }

    }
}
