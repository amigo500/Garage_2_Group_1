using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Text.Encodings.Web;

namespace Garage_2_Group_1.TagHelpers
{
    [HtmlTargetElement("parked")]
    public class ParkedImageTagHelper : TagHelper
    {
        public string? RegNr { get; set; }

        private readonly IParkingService _ps;

        public ParkedImageTagHelper(IParkingService ps)
        {
            _ps = ps;
        }
        // <img src="~/images/details-empty.png" class="card-img-top" alt="Vehicle Data">
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.AddClass("parked", HtmlEncoder.Default);

            var parkedImg = "/images/details.jpg";
            var notParkedImg = "/images/details-empty.png";

            var builder = new StringBuilder();

            if (_ps.IsParked(RegNr))
                builder.Append($"<img src='{parkedImg}' class='card-img-top' alt='Vehicle Data'");
            else
                builder.Append($"<img src='{notParkedImg}' class='card-img-top' alt='Vehicle Data'");

            output.Content.SetHtmlContent(builder.ToString());
        }
    }
}
