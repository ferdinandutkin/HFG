using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents;

public class OptionsFormViewComponent : ViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}