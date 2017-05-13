using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CodePersuit.Service.Core.Models
{
    public class CodeCoverageFile
    {
        public CodeCoverageType FileType { get; set; }
        public string Filename { get; set; }
        public string FileContent { get; set; }
    }
}
