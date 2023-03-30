using DbDaTaAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        AccountManager _accManaGer = new AccountManager();


        public ActionResult Login(Account AccountFroomView)
        {

            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
        public JsonResult CheckLogin(Account AccountFroomView)
        {
            var account = _accManaGer.Check_GetAccountByName(AccountFroomView);
            var kiemTraAcc = new CheckMessage();
            if (account != null && account.IDAccount > 0)
            {
                Session.Add("SessionLogin_TEN_MUON_DAT", account.IDAccount);

                kiemTraAcc.ResponseCode = 1;
                kiemTraAcc.ResponseMessge = "Đăng nhập thành công";
            }
            else
            {
                kiemTraAcc.ResponseCode = -1;
                kiemTraAcc.ResponseMessge = "Đăng nhập thất bại";
            }
            return Json(kiemTraAcc, JsonRequestBehavior.AllowGet);
        }
    }
}