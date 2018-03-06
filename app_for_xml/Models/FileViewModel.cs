namespace app_for_xml.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using domain.entities;

    public class FileViewModel
    {
        public class FileList
        {
            public IEnumerable<File> Files { get; set; }
        }

        public class CurrentFile
        {
            public long Id { get; set; }

            [Required]
            [Display(Name = "Имя файла")]
            public string FileName { get; set; }

            [AllowHtml]
            public string FileContent { get; set; }

            public File File { get; set; }
            public FileVersion Version { get; set; }


            public CurrentFile() { }

            public CurrentFile(File file, string content)
            {
                if (file != null)
                {
                    File = file;
                    Id = file.Id;
                    FileName = File.FileName;
                    if ((File.Versions != null) && (File.Versions.Any()))
                    {
                        var max = File.Versions.Max(x => x.Updated);
                        Version = File.Versions.SingleOrDefault(x => x.Updated == max);
                        FileContent = content;
                    }
                }
            }
        }
    }
}