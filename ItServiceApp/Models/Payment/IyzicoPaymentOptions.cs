using Iyzipay;

namespace ItServiceApp.Models
{
    public class IyzicoPaymentOptions:Options//Iyzico parametre ayarları
    {
        public const string Key = "IyzicoOptions";// Apsetting jsonda ayarlana değerlerin ataması // DİKKAT: apsettingJsonda verilen object ismi ile aynı olamlıdır.
        public string ThreadsCallbackUrl { get; set; }// 3D security 
    }
}
