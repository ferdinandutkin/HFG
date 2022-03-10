using Microsoft.AspNetCore.Mvc;

namespace Web.ViewModels;

public class FunctionListViewComponent : ViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}