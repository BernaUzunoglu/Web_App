using ItServiceApp.Models.Entities;
using System;

namespace ItServiceApp.ViewModel
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string Line { get; set; }
        public string PostCode { get; set; }
        public AdressTypes AddressTypes { get; set; }
        public int StateId { get; set; }
        public string UserId { get; set; }
    }
}
