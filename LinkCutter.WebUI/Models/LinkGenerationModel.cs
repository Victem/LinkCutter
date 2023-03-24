using System.ComponentModel.DataAnnotations;

namespace LinkCutter.WebUI.Models
{
    public class LinkGenerationModel
    {
        [Url]
        [Required(AllowEmptyStrings = false)]
        public string LinkToEncode { get; set; } = string.Empty;

        public string EncodeResult { get; set; } = string.Empty;
    }
}
