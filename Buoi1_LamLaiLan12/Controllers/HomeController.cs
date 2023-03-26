using Buoi1_LamLaiLan12.Models;
using DbDaTaAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buoi1_LamLaiLan12.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var dsConTrollerNhan = DbDaTaAccess.SqlDbHelper.GetListBaiVietByIdDanhMuc();
            return View(dsConTrollerNhan);
        }
        public JsonResult ThemMoiBaiViet(BaiViet baiVietAdd )
        {
            var reultThemMoi = DbDaTaAccess.SqlDbHelper.ThemMoiBaiVietByIdDanhMuc(baiVietAdd);
            var reTurnObj = new ReTurnDaTa();
            if (reultThemMoi>0)
            {
                reTurnObj.ReturnMessage = "Them Moi Thanh Cong";
            }
            else
            {
                reTurnObj.ReturnMessage = "Them Moi Bi Loi";
            }
              //return Json(reultThemMoi);// Sao mình làm z mà nó cũng chạy đc.
              return Json(reTurnObj,JsonRequestBehavior.AllowGet);

        }
        public JsonResult XoaBaiViet(BaiViet baiVietCanXoaFromView)
        {
            var result = DbDaTaAccess.SqlDbHelper.XoaBaiVietByIdBaiViet(baiVietCanXoaFromView);
            var reTurnObj = new ReTurnDaTa();
            if (result > 0)
            {
                reTurnObj.ReturnMessage = "Da Xoa 1 Bai Viet";
            }
            else
            {
                reTurnObj.ReturnMessage = "Chua Thao Tac Gi";
            }
            return Json(reTurnObj, JsonRequestBehavior.AllowGet);
        }
    }
}