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
    CultMember foundMember = _repo.FindMember(cultMemberData);
    if (foundMember != null) throw new Exception("you are already a member of this cult.");
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

  internal string LeaveCult(int id, string userId)
  {
    CultMember cultMember = _repo.GetOne(id);
    if (cultMember == null) throw new Exception($"No membership at id: {id}");
    if (cultMember.AccountId != userId) throw new Exception("Nacho membership");

    _repo.Remove(id);
    return $"You left the cult, but you'll be back... they always come back.";
  }
}
