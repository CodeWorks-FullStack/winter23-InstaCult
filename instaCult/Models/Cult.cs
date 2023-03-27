namespace instaCult.Models;

public class Cult : RepoItem<int>
{

  public string Name { get; set; }
  public string Description { get; set; }
  public string Category { get; set; }
  public string LeaderId { get; set; }
  public Profile Leader { get; set; }
}

// NOTE enums stink, we can come back to this when we have time to mess around
public enum CategoryEnum
{
  BIGINT,
  Fashion,
  Movie,
  Tech,
  Financial,
  Food
}
