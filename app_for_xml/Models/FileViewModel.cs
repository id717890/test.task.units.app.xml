using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using app_for_xml.domain.entities;

namespace app_for_xml.Models
{
    public class FileViewModel
    {
        public class FileList
        {
            public IEnumerable<File> Files { get; set; }
        }

        public class NewFile
        {
            [Required]
            [Display(Name = "Имя файла")]
            public string FileName { get; set; }
            public string FileContent { get; set; }
        }

        public class CurrentFile
        {
            [Required]
            [Display(Name = "Имя файла")]
            public string FileName { get; set; }
            public string FileContent { get; set; }

            public File File { get; set; }
            public FileVersion Version { get; set; }

            public CurrentFile() { }

            public CurrentFile(File file)
            {
                if (file != null)
                {
                    File = file;
                    if (Version == null)
                    {
                        var max = File.Versions.Max(x => x.Updated);
                        Version = File.Versions.SingleOrDefault(x => x.Updated == max);
                        FileContent = Version.Data;
                    }
                    FileName = File.FileName;
                }
            }
        }
    }
}