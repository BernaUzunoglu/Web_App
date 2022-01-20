using DevExtreme.AspNet.Data;
using ItServiceApp.Extensions;
using ItServiceApp.Models.Identity;
using ItServiceApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ItServiceApp.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("[controller]/[action]")]
  
    [Authorize(Roles="Admin")]
    public class UserApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserApiController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetUsers(DataSourceLoadOptions loadOptions)
        {
            var data = _userManager.Users;
           // var users = _userManager.Users.OrderBy(x => x.CreateDate);.ToList();

            //return Ok(new JsonResponseViewModel()//ajax ile verileri datagridLoada yüklemek için users verilerine ulaşma
            //{
            //    Data = users
            //});
            return Ok(DataSourceLoader.Load(data,loadOptions));//
           // return Ok(users);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateUsers(string key,string values)
        {
            var data=_userManager.Users.FirstOrDefault(x=>x.Id == key);
            if (data == null)
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {

                    IsSuccess=false,
                    ErrorMessage="Kullanıcı adı bulunamadı"
                });

            JsonConvert.PopulateObject(values, data);// Düncellenene veriler güncelleniyor değişiklik olmayanlar aynen kalıyor
            if (!TryValidateModel(data))
                return BadRequest(ModelState.ToFullErrorString());

            var result= await _userManager.UpdateAsync(data);
            if (!result.Succeeded)
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı Güncellenemedi"
                });
            return Ok(new JsonResponseViewModel());
        }

        [HttpGet]
        public IActionResult GetTest()
        {
            var users = new List<UserProfileViewModel>();
            for (int i = 0; i < 10000; i++)
            {
                users.Add(new UserProfileViewModel
                {
                    Email = "Deneme" + i,
                    Surname = "Soyad" + i,
                    Name = "ad" + i
                });
                
            }
            return Ok(new JsonResponseViewModel()
            {
                Data = users
            });
        }
        
    }
}
