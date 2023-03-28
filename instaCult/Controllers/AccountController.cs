namespace instaCult.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly CultMembersService _cultMembersService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, CultMembersService cultMembersService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _cultMembersService = cultMembersService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("memberships")]
  [Authorize]
  public async Task<ActionResult<List<CultMembership>>> GetCultMemberships()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<CultMembership> memberships = _cultMembersService.GetCultMemberships(userInfo.Id);
      return Ok(memberships);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
