namespace instaCult.Models;


public class Profile : RepoItem<string>
{
  public string Name { get; set; }
  public string Picture { get; set; }

}
public class Account : Profile
{
  public string Email { get; set; }
}

public class Cultist : Profile
{
  public int CultMemberId { get; set; }
}
