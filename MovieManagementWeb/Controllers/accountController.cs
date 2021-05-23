using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLibrary;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieUILayer.Controllers
{
  
    public class accountController : Controller
    {
        private UserManager<AppUser> umgr;
        private SignInManager<AppUser> smgr;
        IConfiguration conf;

        public accountController(UserManager<AppUser> um, SignInManager<AppUser> sm, IConfiguration c)
        {
            umgr = um;
            smgr = sm;
            conf = c;
        }

        public async Task<IActionResult> Index()
        {

            //AppUser user = await umgr.GetUserAsync(HttpContext.User);
            //string message = "Hello & welcome " + user.UserName;
            //return View((Object)message);
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            //if (ModelState.IsValid)
            //{
            AppUser appUser = await umgr.FindByNameAsync(login.username);
            if (appUser != null)
            {
                await smgr.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await smgr.PasswordSignInAsync(appUser, login.password, false, false);
                if (result.Succeeded)
                {
                    //var userToken = LoginUser(login);
                    //if (userToken != null)
                    //{
                    //    //Save token in session object
                    //    HttpContext.Session.SetString("JWToken", userToken);

                    //}
                    return RedirectToAction("Customer", "Movie", new { area = "" });
                }
                // return RedirectToAction("index");
            }
            ModelState.AddModelError(nameof(login.username), "Login Failed: Invalid username or password");
            //}
            return View(login);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {

            Login login = new Login();
            return View(login);
        }

        [AllowAnonymous]
        public IActionResult AdminLogin(string returnUrl)
        {
            Login login = new Login();
           
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await umgr.FindByNameAsync(login.username);
                if (appUser != null)
                {
                    await smgr.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await smgr.PasswordSignInAsync(appUser, login.password, false, false);
                    if (result.Succeeded)
                    {
                        //var userToken = LoginUser(login);
                        //if (userToken != null)
                        //{
                        //    //Save token in session object
                        //    HttpContext.Session.SetString("JWToken", userToken);

                        //}
                        return RedirectToAction("movielist", "Movie", new { area = "" });
                    }
                }
                ModelState.AddModelError(nameof(login.username), "Login Failed: Invalid UserName or password");
            }
            return View(login);
        }
        [AllowAnonymous]
        public IActionResult Create() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(User m)
        {

            if (ModelState.IsValid)
            {
                var usr = new AppUser
                {
                    UserName = m.name,
                    Email = m.email,
                    
                    SecurityQuestion = m.secques,
                    SecurityAnswer = m.secans
                };
                AppUser appUser = await umgr.FindByNameAsync(m.name);
                if (appUser == null)
                {
                    var rs = await umgr.CreateAsync(usr, m.password);

                    if (rs.Succeeded)
                    {
                        rs = await umgr.AddToRoleAsync(usr, "Customer");
                        if (!rs.Succeeded)
                        {

                            return RedirectToAction("Index");
                        }
                        else
                            return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (IdentityError error in rs.Errors)
                            ModelState.AddModelError("", error.Description);
                    }

                }
                ModelState.AddModelError("", "Username already exists");

                
            }
            return View(m);
        }
        [AllowAnonymous]
        public IActionResult err()
        {
            return Content("user related error");
        }

        public async Task<IActionResult> Logout()
        {
            await smgr.SignOutAsync();
            //HttpContext.Session.Clear();
            return RedirectToAction("StartPage", "Movie");

        }

        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}
        //public IActionResult Changepassword()
        //{
        //    return View();
        //}
        //private void Errors(IdentityResult result)
        //{
           
            
        //}

        public IActionResult ErrorPage(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(ModelState);
        }

        //[HttpGet("TokenGen")]
        //public string LoginUser(Login user)
        //{
        //    //Authentication successful, Issue Token with user credentials - JRozario
        //    //Provide the security key which was given in the JWToken configuration in Startup.cs - JRozario

        //    //FMS-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["Jwt:Key"]));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    //Generate Token for user - JRozario
        //    var JWToken = new JwtSecurityToken(
        //    issuer: conf["Jwt:Issuer"],
        //    audience: conf["Jwt:Issuer"],
        //    claims: GetUserClaims(user),
        //    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
        //    expires: new DateTimeOffset(DateTime.Now.AddMinutes(10)).DateTime,
        //    //Using HS256 Algorithm to encrypt Token - JRozario
        //    signingCredentials: credentials
        //    );

        //    var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
        //    return token;

        //}
        //private IEnumerable<Claim> GetUserClaims(Login user)
        //{
        //    IEnumerable<Claim> claims = new Claim[]
        //            {
        //            new Claim("Username", user.username),
        //            new Claim("Password", user.password),
        //            //new Claim("USERID", user.Id),
        //            //new Claim("USERNAME", user.UserName),
        //            //new Claim(user.Role, user.Role),
        //            //new Claim("Airline", user.Airline)
        //            };
        //    return claims;
        //}
    }
}
