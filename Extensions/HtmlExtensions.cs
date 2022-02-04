using Garage_2_Group_1.Models;
using Garage_2_Group_1.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Garage_2_Group_1.Extensions
{
    public static class HtmlExtensions
    {

        public static IEnumerable<SelectListItem> GetEnumValueSelectList<TEnum>(this IHtmlHelper htmlHelper, string selectedValue, int maxSize = 3) where TEnum : struct
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
            if(typeof(TEnum) == typeof(VehicleType))
            {
                list.Where(x =>
                        GetVehicleSize((VehicleType)Enum.Parse(typeof(VehicleType), x.Text, true)) > maxSize)
                    .ToList()
                    .ForEach(x => x.Disabled = true);
            }
            return list;
        }

        public static IEnumerable<SelectListItem> GetEnumValueSelectList<TEnum>(this IHtmlHelper htmlHelper, int maxSize = 3) where TEnum : struct
        {
            var list = new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.ToString(),
                        Value = x.ToString()
                    }), "Value", "Text");
            if (typeof(TEnum) == typeof(VehicleType))
            {
                list.Where(x =>
                        GetVehicleSize((VehicleType)Enum.Parse(typeof(VehicleType), x.Text, true)) > maxSize)
                    .ToList()
                    .ForEach(x => x.Disabled = true);
            }
            return list;
        }

        private static int GetVehicleSize(VehicleType type)
        {
            int size = 0;
            switch (type)
            {
                case VehicleType.Bus:
                    size = 2;
                    break;
                case VehicleType.Boat:
                    size = 3;
                    break;
                case VehicleType.Airplane:
                    size = 3;
                    break;
                case VehicleType.Car:
                    size = 1;
                    break;
                case VehicleType.Motorcycle:
                    size = 1;
                    break;
                default:
                    size = 1;
                    break;

            }
            return size;
        }
    }
}
