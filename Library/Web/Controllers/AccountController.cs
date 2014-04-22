using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private DatаManager dataManager;
        public AccountController(DatаManager datаManager)
        {
            this.dataManager = datаManager;
        }
        public ActionResult Index()
        {
            return View();
        }
    [HttpPost]
        public ActionResult Index(LoginVievModel model )
        {
        if(ModelState.IsValid)
        {
            if(dataManager.MembershipProvider.ValidateUser(model.UserName,model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName,false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("","неудачная попытка входа на сайт");

        }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                MembershipCreateStatus status = dataManager.MembershipProvider.CreateUser(model.UserName, model.Password,
                                                                                          model.Email, model.FirstName,
                                                                                          model.LastName,
                                                                                          model.MiddleName,
                                                                                          model.NumberStudent);
                if(status==MembershipCreateStatus.Success)
                {
                    return View("Success");
                }
                ModelState.AddModelError("",GetMembershipCreateResult(status));
            }
            return View();
        }
        public string GetMembershipCreateResult(MembershipCreateStatus status)
        {
            if(status==MembershipCreateStatus.DuplicateEmail)
            {
                return "Пользователь с таким email адресом уже существует";
            }
            if (status == MembershipCreateStatus.DuplicateUserName)
            {
                return "Пользователь с таким именем уже существует";
            }
            return "неизвестная ошибка";
        }
    }
}
