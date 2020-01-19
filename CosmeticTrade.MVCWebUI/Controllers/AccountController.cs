using CosmeticTrade.BLL.Repositories.RepositoryClass;
using CosmeticTrade.DAL.ORM.Context;
using CosmeticTrade.DAL.ORM.Entity;
using CosmeticTrade.MVCWebUI.Models.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CosmeticTrade.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        UserRepository ur = new UserRepository();
        RoleRepository rr = new RoleRepository();

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                string userName = ur.UserCheck(model.UserName, model.Password);
                if (!ur.CheckUserName(model.UserName))
                {
                    ViewBag.LoginUserError = "Böyle bir kullanıcı yok.";
                    return View(model);
                }
                if (userName != null)
                {
                    if (ur.SelectAll().FirstOrDefault(i => i.Username == userName).ConfirmMail == false)
                    {
                        ViewBag.LoginUserError = "You have not confirmed your email address.Please check your email address.";
                        return View(model);
                    }
                    FormsAuthentication.SetAuthCookie(userName, false);


                    if (ur.RolesByUserName(userName).Any(s => s.Equals("Admin")))
                    {
                        return RedirectToAction("List", "Product", new { area = "Admin" });
                    }




                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginUserError = "şifre veya kullanıcı adı hatalı.";
                }

            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult NoAccess()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                if (ur.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("UserName", "Error username same");
                    return View(model);
                }
                if (ur.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("Email", "Error Email same");
                    return View(model);
                }

                var newUser = new User();
                newUser.Name = model.Name;
                newUser.Surname = model.SurName;
                newUser.Username = model.UserName;
                newUser.Email = model.Email;
                newUser.Password = model.Password;
                newUser.ShipAddress = model.ShipAddress;
                newUser.Roles.Add(rr.SelectAll().FirstOrDefault(i => i.Name == "User"));
                if (ur.AddOrUpdate(newUser))
                {
                    return RedirectToAction("RegisterInfo", "Account", new { email = model.Email });
                }
                else
                {
                    ModelState.AddModelError("Name", "Error Creating User");
                }
            }
            return View(model);
        }

        public void EmailConfirm(string email)
        {
            var user = ur.SelectAll().FirstOrDefault(i => i.Email == email);
            if (user != null)
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.office365.com";
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("ctecommerce@hotmail.com", "CT123456");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ctecommerce@hotmail.com", "CosmeticTrade");
                mail.To.Add(email);
                mail.Subject = "Email Confirmation.";
                mail.IsBodyHtml = true;
                mail.Body = "<a href='http://localhost:52378/Account/MailApprove?id=" + user.Id + "'>Click</a> to confirm your e-mail address ";
                smtp.Send(mail);
            }
        }

        public ActionResult RegisterInfo(string email)
        {
            EmailConfirm(email);
            object mail = email;
            return View(mail);
        }

        public ActionResult MailApprove(int id)
        {
            var user = ur.SelectById(id);
            if (user != null)
            {
                user.ConfirmMail = true;
                ur.AddOrUpdate(user);
                return View(user);
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = ur.SelectAll().FirstOrDefault(i => i.Email == model.Email);
                if (user != null)
                {
                    PasswordSend(user.Email);
                  return RedirectToAction("PasswordInfo", "Account", new { email = user.Email });
                }
                ModelState.AddModelError("Email", "Böyle bir kullanıcı yok");

            }
            return View(model);
        }

        public ActionResult PasswordInfo(string email)
        {           
            object mail = email;
            return View(mail);
        }
        public void PasswordSend(string email)
        {
            var user = ur.SelectAll().FirstOrDefault(i => i.Email == email);
            if (user != null)
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.office365.com";
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("ctecommerce@hotmail.com", "CT123456");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ctecommerce@hotmail.com", "CosmeticTrade");
                mail.To.Add(email);
                mail.Subject = "User Password";
                mail.IsBodyHtml = true;
                mail.Body = "<p>Talebiliz üzere kullanıcı adı ve şifreniz aşağıda yazmaktadır.</p><p> UserName: " + user.Username + "</p><p> Password: " + user.Password + "</p> ";
                smtp.Send(mail);
            }
        }
    }
}