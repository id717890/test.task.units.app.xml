namespace app_for_xml.Controllers
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using domain.services;
    using infrastructure.services;
    using Models;

    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IStringService _stringService;
        private readonly IXmlService _xmlService;
        private readonly ILogger _logger;

        public FileController(IFileService fileService, IStringService stringService, IXmlService xmlService, ILogger logger)
        {
            _fileService = fileService;
            _stringService = stringService;
            _xmlService = xmlService;
            _logger = logger;
        }

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
                _logger.Error(e.Message);
                return RedirectToAction("Index", "Error", new { message = e.Message });
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

            //// Проверяем что третья часть имени содержит не более 7 любых символов
            //if (!_xmlService.IsXmlValid(model.FileContent)) ModelState.AddModelError("FileName", @"Третья часть имени файла должна содержать не более 7 любым символов");


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _logger.Info("Начато сохранение файла"+model.FileName);
                var file = _fileService.Create(model.FileName, model.FileContent);
                if (file != null) 
                {
                    _logger.Info("Файл успешно сохранен" + model.FileName);
                    return RedirectToAction("Edit", "File", new { id = file.Id, vesrion = 0 });

                }
                return RedirectToAction("Index", "Error", new { message = "Пустой объект" });
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return RedirectToAction("Index", "Error", new { message = e.Message });
            }
        }

        public ActionResult Edit(long id, long version = 0)
        {
            try
            {
                var file = _fileService.GetFileById(id);
                if (file == null) return RedirectToAction("Index", "Error", new { message = "Объект не найден" });
                var fileVesion = version == 0 ? file.GetLatestVersion() : file.GetVersionById(version);
                var content = _xmlService.CreateXmlContent(file.FileName, fileVesion.Version, fileVesion.Updated, fileVesion.Data);
                var model = new FileViewModel.CurrentFile(file, HttpUtility.HtmlDecode(content));
                return View(model);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return RedirectToAction("Index", "Error", new { @message = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(FileViewModel.CurrentFile model)
        {
            var file = _fileService.GetFileById(model.Id);
            model.File = file;
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
                // Если имя файла поменялось то это уже другой файл, поэтому создаем новый файл в БД
                if (file.FileName != model.FileName)
                {
                    var newFile = _fileService.Create(model.FileName, _xmlService.ExtractOnlyContent(model.FileContent));
                    if (newFile != null) return RedirectToAction("Edit", "File", new { id = newFile.Id, vesrion = 0 });
                    return RedirectToAction("Index", "Error", new { message = "Пустой объект" });
                }
                // Если имя файла не поменялось то создаем новую версию текущего файла
                else
                {
                    if (_xmlService.IsXmlValid(model.FileContent))
                    {
                        _fileService.CreateVersion(file.Id, _xmlService.ExtractOnlyContent(model.FileContent));
                    }
                    else
                    {
                        TempData["errors"] = "В XML файле обнаружены ошибки";
                        return View(model);
                    }
                }
                return RedirectToAction("Edit", new { id = file.Id, version = 0 });
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return RedirectToAction("Index", "Error", new { @message = e.Message });
            }
        }


        [HttpPost]
        public ActionResult UploadXml(HttpPostedFileBase upload)
        {
            try
            {
                var reader = new StreamReader(upload.InputStream);
                var doc = XDocument.Load(reader);

                return View("Create", new FileViewModel.CurrentFile
                {
                    FileContent = doc.ToString(),
                    FileName = Path.GetFileNameWithoutExtension(upload.FileName)
                });
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return RedirectToAction("Index", "Error", new { @message = e.Message });
            }
        }

        [HttpGet]
        public ActionResult DownloadXml(long id)
        {
            try
            {
                var fileVersion = _fileService.GetFileVersionById(id);
                if (fileVersion == null) return RedirectToAction("Index", "Error", new { message = "Объект не найден" });
                var doc = _xmlService.CreateXmlContent(fileVersion.File.FileName, fileVersion.Version,
                    fileVersion.Updated, fileVersion.Data);
                return File(Encoding.UTF8.GetBytes(HttpUtility.HtmlDecode(doc)), "application/xml", fileVersion.File.FileName + ".xml");
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return RedirectToAction("Index", "Error", new { @message = e.Message });
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            try
            {
                _fileService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return RedirectToAction("Index", "Error", new { @message = e.Message });
            }
        }
    }
}