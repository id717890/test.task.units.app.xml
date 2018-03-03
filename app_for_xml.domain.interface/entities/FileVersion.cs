namespace app_for_xml.domain.@interface.entities
{
    using System;

    public class FileVersion : Entity
    {
        public virtual File File { get; set; }
        public string Version { get; set; }
        public string Data { get; set; }
        public DateTime Updated { get; set; }
    }
}
