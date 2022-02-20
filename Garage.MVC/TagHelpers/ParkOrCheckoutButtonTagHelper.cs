using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Text.Encodings.Web;
namespace Garage_2_Group_1.TagHelpers
{
    [HtmlTargetElement("poc", Attributes = "[reg-nr],[type-id]")]
    public class ParkOrCheckoutButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("reg-nr")]
        public string RegNr { get; set; } = String.Empty;

        [HtmlAttributeName("type-id")]
        public int TypeId { get; set; }

        private readonly IParkingService _ps;
        private readonly GarageContext2 _db;

        public ParkOrCheckoutButtonTagHelper(IParkingService ps, GarageContext2 db)
        {
            _ps = ps;
            _db = db;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.AddClass("poc", HtmlEncoder.Default);
            output.AddClass("btn", HtmlEncoder.Default);
            output.AddClass("btn-danger", HtmlEncoder.Default);


            if (_ps.IsParked(RegNr))
            {
                output.Attributes.SetAttribute("asp-action", "Checkout");
                output.Attributes.SetAttribute("asp-controller", "Vehicles");
                output.Attributes.SetAttribute("asp-route-id", RegNr);
                output.Content.Append("Checkout");
            }

            else
            {
                var query = _db.VehicleType.FirstOrDefault(t => t.Id == TypeId);
                var size = query?.Size ?? -1;

                output.AddClass("park-button", HtmlEncoder.Default);
                output.Attributes.SetAttribute("regNr", RegNr);
                output.Attributes.SetAttribute("size", size);
                output.Content.Append("Park");
            }
        }
    }
}
