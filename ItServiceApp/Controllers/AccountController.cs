using ItServiceApp.Extensions;
using ItServiceApp.Models;
using ItServiceApp.Models.Identity;
using ItServiceApp.Services;
using ItServiceApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ItServiceApp.Controllers
{
    public class AccountController : Controller
    {
        //servislerin kullanımı için fieldlar oluşturuldu
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<AplicationRole> _roleManager;
        private readonly IEmailSender _emailSender;

        //field lar için referans eşleme yapıldı.
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<AplicationRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager= roleManager;
            _emailSender = emailSender;
            CheckRoles();
        }

        private void CheckRoles()
        {
            foreach (var roleName in RoleNames.Roles)
            {
                if (!_roleManager.RoleExistsAsync(roleName).Result)
                {
                    var result = _roleManager.CreateAsync(new AplicationRole()
                    {
                        Name = roleName,
                    }).Result;
                }
            }
        }

        [AllowAnonymous]// Anonim kullanıcılarının(Kimliği doğrulanmamış) bu işlemi yapabileceğini bildirdik.
                        //Zorunlu kılınan yetkilendirmeyi atlamak içinde kullanılır.
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        //async çalışınca kitlenme olmaz işlem  bitince sistem kaldığı yerden devam eder.
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Password=string.Empty;
                model.ConfirmPassword=string.Empty;
                return View(model);
            }

            var user=await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Bu kullanıcı adı daha önce sisteme kaıt edilmiştir.");
                return View(model);
            }

            user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.Email), "Bu kullanıcı adı daha önce sisteme kaıt edilmiştir.");
                return View(model);
            }


            user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if (result.Succeeded)
            {
                //TODO:kullanıcıya rol atama  TODO ifadesi yapılacaklar listesini tutuar.
                var count =_userManager.Users.Count();

                result = await _userManager.AddToRoleAsync(user, count == 1 ? RoleNames.Admin : RoleNames.User);
                //if(count==1)//admin
                //{
                //    result=await _userManager.AddToRoleAsync(user,RoleNames.Admin);
                //}
                //else//user
                //{
                //    result = await _userManager.AddToRoleAsync(user, RoleNames.User);

                //}


                //TODO:kullanıcıya mail dogrulaması atma

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code=WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl=Url.Action("ConfirmEmail","Account", new {userId=user.Id,code=code},protocol:Request.Scheme);

                var emailMesage = new EmailMessage()
                {
                    Contacts = new string[] { user.Email },
                    Body = $"Please confirm your account by <a href ='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>",
                    Subject = "Confirm your email"
                };

                await _emailSender.SendAsyc(emailMesage);
                //TODO:giriş sayfasına yönlendirme
            }
            else
            {

                // ModelState.AddModelError(string.Empty, "kayıt işleminde bir hata oluştu");
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());

                return View(model);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail( string userId, string code)
        {
            if(userId == null || code == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user =await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return NotFound($" Unable to load user with ID'{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result= await _userManager.ConfirmEmailAsync(user, code);
            ViewBag.StatusMessage=result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";

            if(result.Succeeded && _userManager.IsInRoleAsync(user,RoleNames.Passive).Result)
            {
               await _userManager.RemoveFromRoleAsync(user,RoleNames.Passive);
                await _userManager.AddToRoleAsync(user,RoleNames.User);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe,true);

            if (result.Succeeded)
            {

                await _emailSender.SendAsyc(new EmailMessage()
                {
                    Contacts = new string[] { "bernauzunoglu58@gmail.com" },
                    Body = $"{HttpContext.User.Identity.Name} Sisteme giriş yaptı",
                    Subject = $"Merhaba Berna mail geldi mi"

                });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty,"Kullanıcı adı veya şifre hatalı");
                return View(model);
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var model = new UserProfileViewModel
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Profile( UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());

            user.Name = model.Name;
            user.Surname = model.Surname;

            if(user.Email!= model.Email)
            {
                await _userManager.RemoveFromRoleAsync(user, RoleNames.User);
                await _userManager.AddToRoleAsync(user, RoleNames.Passive);

                user.Email = model.Email;
                user.EmailConfirmed = false;

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Scheme);

                var emailMesage = new EmailMessage()
                {
                    Contacts = new string[] { user.Email },
                    Body = $"Please confirm your account by <a href ='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>",
                    Subject = "Confirm your email"
                };

                await _emailSender.SendAsyc(emailMesage);


            }
            var result =await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
            }

            return View(model);
        }
       
    }

   
}
