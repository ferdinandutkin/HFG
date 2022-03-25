using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Web.Views;

public static class HtmlExtensions
{
    public static IEnumerable<SelectListItem> GetEnumValueSelectList<TEnum>(this IHtmlHelper htmlHelper) where TEnum : struct, Enum 
    {
        var enumType = typeof(TEnum);
        return new SelectList(Enum.GetValues<TEnum>()
            .Select(x =>
                new SelectListItem
                {
                    Text = enumType.GetField(x.ToString())!.GetCustomAttribute<DisplayAttribute>()?.Name ?? x.ToString(),
                    Value = x.ToString()
                }), "Value", "Text");
    }
}
