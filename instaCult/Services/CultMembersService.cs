namespace instaCult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _repo;

  public CultMembersService(CultMembersRepository repo)
  {
    _repo = repo;
  }

  internal CultMember CreateCultMember(CultMember cultMemberData)
  {
    CultMember cultMember = _repo.Create(cultMemberData);
    return cultMember;
  }

  internal List<Cultist> GetCultists(int cultId)
  {
    List<Cultist> cultists = _repo.GetCultists(cultId);
    return cultists;
  }

  internal List<CultMembership> GetCultMemberships(string userId)
  {
    List<CultMembership> memberships = _repo.GetCultMemberships(userId);
    return memberships;
  }
}
