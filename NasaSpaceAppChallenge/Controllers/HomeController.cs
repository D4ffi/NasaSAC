using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NasaSpaceAppChallenge.Models;
using NasaSpaceAppChallenge.Services;

namespace NasaSpaceAppChallenge.Controllers;

public class HomeController : Controller
{
    private readonly NeoApi _appSettings;
    private readonly ILogger<HomeController> _logger;
    private readonly INeoRequest _neoRequest;

    // Single constructor for dependency injection
    public HomeController(IOptions<NeoApi> _appsettings,ILogger<HomeController> logger, INeoRequest neoRequest)
    {
        _appSettings = _appsettings.Value;
        _logger = logger;
        _neoRequest = neoRequest;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<IActionResult> GetFeedFromNasa()
    {
        try
        {
            var neoData = await _neoRequest.GetNeoFeed("2021-09-28", "2021-11-17");
            neoData.EnsureSuccessStatusCode();
            var neoresponse = await neoData.Content.ReadFromJsonAsync<NeoFeedResponse>();
            return Json(neoresponse);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error fetching data from NASA API");
            return BadRequest("There was an error processing your request.");
        }
    }
}