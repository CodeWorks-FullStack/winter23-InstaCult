namespace instaCult.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultMembersController : ControllerBase
{
  private readonly CultMembersService _cultMembersService;
  private readonly Auth0Provider _auth;

  public CultMembersController(CultMembersService cultMembersService, Auth0Provider auth)
  {
    _cultMembersService = cultMembersService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<CultMember>> CreateCultMember([FromBody] CultMember cultMemberData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      cultMemberData.AccountId = userInfo.Id;
      CultMember cultMember = _cultMembersService.CreateCultMember(cultMemberData);
      return Ok(cultMember);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> LeaveCult(int id)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      string message = _cultMembersService.LeaveCult(id, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
