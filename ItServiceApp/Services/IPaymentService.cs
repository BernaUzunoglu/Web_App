using ItServiceApp.Models.Payment;
using System.Collections.Generic;

namespace ItServiceApp.Services
{
    public interface IPaymentService
    {
        public InstallmentModel CheckInstallments(string binNumber, decimal price);//kart ilk 6 hanesi
        public PaymentResponseModel Pay( PaymentModel model);
    }
}
