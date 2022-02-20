using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Text.Encodings.Web;

namespace Garage_2_Group_1.TagHelpers
{
    [HtmlTargetElement("parked")]
    public class ParkedImageTagHelper : TagHelper
    {
        public string RegNr { get; set; } = String.Empty;

        private readonly IParkingService _ps;

        public ParkedImageTagHelper(IParkingService ps)
        {
            _ps = ps;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.AddClass("parked", HtmlEncoder.Default);
            output.AddClass("card-img-top", HtmlEncoder.Default);

            var parkedImg = "/images/details.jpg";
            var notParkedImg = "/images/details-empty.png";

            if (_ps.IsParked(RegNr))
                output.Attributes.SetAttribute("src", parkedImg);
            else
                output.Attributes.SetAttribute("src", notParkedImg);

            output.Attributes.SetAttribute("alt", "Vehicle Parked/Unparked Image");
        }
    }
}
