﻿using System.Collections.Generic;

namespace ItServiceApp.Models.Payment
{
    public class PaymentModel
    {
        public string PaymentId { get; set; }
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public int Installment { get; set; }
        public CardModel CardModel { get; set; }
        public List<BasketModel> BasketList { get; set; }
        public CustomerModel Customer { get; set; }
        public AddressModel Adress{ get; set; }
    }
}