using System;

namespace ItServiceApp.ViewModel
{
    public class JsonResponseViewModel
    {
        public bool IsSuccess { get; set; } = true;//jsondan gelen veri başarılı gelmiş mi yani veri geliyor ma başarılımı yada hatasız mı
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
    }
}
