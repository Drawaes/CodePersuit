// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace CodePersuit.Service.Sdk.Models
{
    using CodePersuit.Service;
    using CodePersuit.Service.Sdk;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class CodeCoverageFile
    {
        /// <summary>
        /// Initializes a new instance of the CodeCoverageFile class.
        /// </summary>
        public CodeCoverageFile()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CodeCoverageFile class.
        /// </summary>
        /// <param name="fileType">Possible values include: 'Coveralls'</param>
        public CodeCoverageFile(string fileType = default(string), string filename = default(string), string fileContent = default(string))
        {
            FileType = fileType;
            Filename = filename;
            FileContent = fileContent;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'Coveralls'
        /// </summary>
        [JsonProperty(PropertyName = "fileType")]
        public string FileType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "filename")]
        public string Filename { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fileContent")]
        public string FileContent { get; set; }

    }
}