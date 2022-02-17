using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Extensions
{
    public static class HtmlExtensions
    {

        public static IEnumerable<SelectListItem> GetEnumValueSelectList<TEnum>(this IHtmlHelper htmlHelper, string selectedValue) where TEnum : struct
        {
            var list = new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.ToString(),
                        Value = x.ToString()
                    }), "Value", "Text");
            var selected = list.Where(x => x.Value == selectedValue).First();
            selected.Selected = true;
            return list;
        }
    }
}

