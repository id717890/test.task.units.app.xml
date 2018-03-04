using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using app_for_xml.domain.entities;
using app_for_xml.domain.services;
using app_for_xml.infrastructure.services;
using app_for_xml.Models;
using Ninject;

namespace app_for_xml.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IStringService _stringService;

        public FileController(IFileService fileService, IStringService stringService)
        {
            _fileService = fileService;
            _stringService = stringService;
        }

        // GET: File
        public ActionResult Index()
        {
            try
            {
                var model = new FileViewModel.FileList()
                {
                    Files = _fileService.GetAllFiles()
                };
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new FileViewModel.CurrentFile());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FileViewModel.CurrentFile model)
        {
            //Проверяем модель на валидность
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Проверяем что имя состоит из трех частей
            if (!_stringService.CheckFormat(model.FileName)) ModelState.AddModelError("FileName", @"Имя файла не соответствует формату");

            // Проверяем что первая часть имени содержит только русские буквы (не более 100)
            if (!_stringService.FirstPartShouldBeCyrilic(model.FileName)) ModelState.AddModelError("FileName", @"Первая часть имени файла должна содержать только русские буквы (не более 100 символов)");

            // Проверяем что вторая часть имени содержит только цифры (не более 1 символа)
            if (!_stringService.SecondPartShouldBeNumber(model.FileName)) ModelState.AddModelError("FileName", @"Вторая часть имени файла должна содержать только цифры (не более 1 символа)");

            // Проверяем что третья часть имени содержит не более 7 любых символов
            if (!_stringService.ThirdPartShouldBeAny(model.FileName)) ModelState.AddModelError("FileName", @"Третья часть имени файла должна содержать не более 7 любым символов");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var file = _fileService.Create(model.FileName, model.FileContent);
                if (file != null) return RedirectToAction("Edit", new { id = file.Id });
                return RedirectToAction("Index", "Error", new { message = "Пустой объект" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { @message = e.Message });
            }
        }

        public ActionResult Edit(long id)
        {
            try
            {
                var file = _fileService.GetFileById(id);
                if (file == null) return RedirectToAction("Index", "Error", new { message = "Объект не найден" });
                var xml = new XDocument();

                var el1=new XElement("test1","test1");
                var el2=new XElement("test2","test2");
                var content=new XElement("content");
                content.Add(el1);
                content.Add(el2);

                xml.Add(content);

                var x = xml.ToString();
                return File(Encoding.UTF8.GetBytes(x), "application/xml", "test");

                return Content(x, "text/xml");

                var model = new FileViewModel.CurrentFile(file);
                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { @message = e.Message });
            }
        }
    }
}