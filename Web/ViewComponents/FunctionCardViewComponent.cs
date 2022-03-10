using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents;

public class FunctionCardViewComponent : ViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}