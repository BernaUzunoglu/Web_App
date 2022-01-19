﻿using ItServiceApp.Models.Identity;
using ItServiceApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ItServiceApp.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles="Admin")]
    public class UserApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserApiController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetUsers()
        { 
            var users=_userManager.Users.OrderBy(x=>x.CreateDate).ToList();
           
            return Ok(new JsonResponseViewModel()
            {
                Data = users
            });
           // return Ok(users);
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
