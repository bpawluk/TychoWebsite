using Microsoft.AspNetCore.Mvc;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("me/funds")]
public class FundsController : ControllerBase
{
    [HttpGet]
    public ActionResult<Funds> GetFunds()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult AddFunds(Funds newFunds)
    {
        throw new NotImplementedException();
    }

    public record Funds(double Amount);
}
