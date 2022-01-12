using Iyzipay;

namespace ItServiceApp.Models
{
    public class IyzicoPaymentOptions:Options
    {
        public const string Key = "IyzicoOptions";
        public string ThreadsCallbackUrl { get; set; }
    }
}
