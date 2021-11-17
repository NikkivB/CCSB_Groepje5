using CCSB_Groepje5.Models;
using CCSB_Groepje5.Models.ViewModels;
using CCSB_Groepje5.Services;
using CCSB_Groepje5.Utility;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _rolemanager;


        public AccountController(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _rolemanager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            if (!_rolemanager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _rolemanager.CreateAsync(new IdentityRole(Helper.Admin));
                await _rolemanager.CreateAsync(new IdentityRole(Helper.Customer));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    Middlename = model.MiddleName,
                    LastName = model.LastName,
                    BankNumber = model.BankNumber,
                    Adress = model.Adress,
                    Postalcode = model.Postalcode,
                    City = model.City,
                    PhoneNumber = model.PhoneNumber,
                    Birthdate = model.Birthdate
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("Registratie", "Groepje_5@gmail.com"));
                        message.To.Add(new MailboxAddress(model.FirstName, model.Email));
                        message.Subject = "Bedankt voor het registreren";
                        message.Body = new TextPart("plain")
                        {
                            Text = "Beste " + model.FirstName + ",\n" + "Er is zojuist een account geregistreerd bij camper-en carvan stalling Bentelo. " +
                            "U kunt inloggen met de volgende gegevens:" + "\n" + "\n" + "Email: " + model.Email + "\n" + "Wachtwoord: " + model.Password + "\n" + 
                            "\n" + "Als deze gegevens niet kloppen of als dit email niet voor u bestemd is, kan je altijd bellen naar: 0687654321" + "\n" + 
                            "Met vriendelijke groet," + "\n" + "CCBS"
                        };
                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.gmail.com", 587, false);
                            client.Authenticate("campergroepje5@gmail.com", "Test123#");

                            client.Send(message);

                            client.Disconnect(true);
                        }           

                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Appointment");
                }
                ModelState.AddModelError("", "Inloggen mislukt");
            }
            return View(model);
        }
    }
}

