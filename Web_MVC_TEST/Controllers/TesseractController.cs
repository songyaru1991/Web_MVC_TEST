using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Web_MVC_TEST.Controllers
{
    public class TesseractController : Controller
    {
        //
        // GET: /Tesseract/
        public ActionResult Index()
        {
            return View();
        }
  
        string filePath = "";
        public ActionResult FileUpload()
        {
            HttpPostedFileBase uploadFile = Request.Files["uploadFile"];
            if (uploadFile != null)
            {
                if (uploadFile.ContentLength > 0)
                {             
                    filePath = Path.Combine(HttpContext.Server.MapPath("~/Uploads"),

                                    Path.GetFileName(uploadFile.FileName));

                    uploadFile.SaveAs(filePath);                 
                }
               return Content("<script>alert('上传成功!');location.href='/Tesseract/Index';</script>");           
            }
            else
            {
                return Content("<script>alert('上传失败!');location.href='/Tesseract/Index';</script>");      
            }
            //  return RedirectToAction("Index");
        }
    }
}