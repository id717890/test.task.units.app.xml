using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using app_for_xml.domain.services;

namespace app_for_xml.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: File
        public ActionResult Index()
        {
            var i=_fileService.GetAllTypes();
            foreach (var i2 in i)
            {
                ViewBag.Test = i2;

            }
            return View();
        }
    }
}