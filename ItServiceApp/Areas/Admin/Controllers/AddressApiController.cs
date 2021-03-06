using DevExtreme.AspNet.Data;
using ItServiceApp.Data;
using ItServiceApp.Extensions;
using ItServiceApp.Models.Entities;
using ItServiceApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ItServiceApp.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]

    public class AddressApiController : Controller
    {
        private readonly MyContext _dbContext;

        public AddressApiController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get(string userId,DataSourceLoadOptions options)
        {
            var data = _dbContext.Addresses
                .Include(x => x.State)
                .ThenInclude(x => x.City)
                .Where(x => x.UserId == userId);//.ToList();
            return Ok(DataSourceLoader.Load(data, options));
        }
        [HttpGet]
        public IActionResult Detail(Guid id, DataSourceLoadOptions loadoptions)
        {
            var data = _dbContext.Addresses.Where(x => x.Id == id);
            return Ok(DataSourceLoader.Load(data, loadoptions));

        }
        [HttpGet]
        public IActionResult Insert(string values)
        {
            var data = new Address();
            JsonConvert.PopulateObject(values, data);// Güncellenene veriler güncelleniyor değişiklik olmayanlar aynen kalıyor
            if (!TryValidateModel(data))
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = ModelState.ToFullErrorString()
                }) ;

           _dbContext.Addresses.Add(data);
            var result = _dbContext.SaveChanges();
            if (result==0)
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Yeni adres kaydedilmedi"
                });
            return Ok(new JsonResponseViewModel());


        }

        [HttpPut]
        public  IActionResult Update(Guid key, string values)
        {
            var data = _dbContext.Addresses.Find(key);
            if (data == null)
                return BadRequest(new JsonResponseViewModel()
                {

                    IsSuccess = false,
                    ErrorMessage = ModelState.ToFullErrorString()
                });

            JsonConvert.PopulateObject(values, data);// Güncellenene veriler güncelleniyor değişiklik olmayanlar aynen kalıyor
            if (!TryValidateModel(data))
                return BadRequest(ModelState.ToFullErrorString());

            var result = _dbContext.SaveChanges();

            if (result==0)
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Adress Güncellenemedi"
                });
            return Ok(new JsonResponseViewModel());
        }
        [HttpDelete]
        public  IActionResult Delete(Guid key)
        {
            var data = _dbContext.Addresses.Find(key);
            if (data == null)
                return StatusCode(StatusCodes.Status409Conflict, "Adress bulunamadı");
            _dbContext.Addresses.Remove(data);

            if (!TryValidateModel(data))
                return BadRequest(ModelState.ToFullErrorString());

            var result = _dbContext.SaveChanges();

            if (result == 0)
                return BadRequest("Silme işlemi başarısız");
               
            return Ok(new JsonResponseViewModel());
        }

        [HttpGet]
        public object CityLookup(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.Cities
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    id = x.Id,
                    Value = x.Id,
                    Text = $"{x.Name}"

                });
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }
        [HttpGet]
        public object StateLookup(int cityId,DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.States
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    id = x.Id,
                    Value = x.Id,
                    Text = $"{x.Name}",
                    CityId = x.CityId

                });
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }
    }
}
