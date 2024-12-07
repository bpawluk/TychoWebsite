using Microsoft.AspNetCore.Mvc;
using Tycho.Structure;
using TychoWebsite.Program.Utils;
using TychoWebsite.Store.Contract.Incoming.Requests;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("me/funds")]
public class FundsController(IApp app) : ControllerBase
{
    private readonly IApp _app = app;

    [HttpGet]
    public async Task<ActionResult<Funds>> GetFunds()
    {
        var request = new GetBalance(Constants.UserId);
        var response = await _app.Execute<GetBalance, GetBalance.Response>(request);
        return Ok(new Funds(response.Amount));
    }

    [HttpPost]
    public async Task<IActionResult> AddFunds(Funds newFunds)
    {
        var request = new AddFunds(Constants.UserId, newFunds.Amount);
        await _app.Execute(request);
        return NoContent();
    }

    public record Funds(decimal Amount);
}