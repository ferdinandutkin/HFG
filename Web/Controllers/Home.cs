using HashCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Web.Hubs;

namespace Web.Controllers;

[Route("/")]
public class Home : Controller
{
    private readonly IHashStatsGenerator _generator;
    private readonly IHubContext<GeneratorHub> _hubContext;

    public Home(IHashStatsGenerator generator, IHubContext<GeneratorHub> hubContext)
    {
        _generator = generator;
        _hubContext = hubContext;
    }

    public IActionResult Index()
    {
        return View();
    }


}