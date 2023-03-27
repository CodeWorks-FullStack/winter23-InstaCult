namespace instaCult.Services;

public class CultsService
{
  private readonly CultsRepository _repo;

  public CultsService(CultsRepository repo)
  {
    _repo = repo;
  }

  internal Cult Create(Cult cultData)
  {
    Cult cult = _repo.Create(cultData);
    return cult;
  }

  internal List<Cult> Get()
  {
    List<Cult> cults = _repo.Get();
    return cults;
  }

  internal Cult GetOne(int id)
  {
    Cult cult = _repo.GetOne(id);
    if (cult == null) throw new Exception($"No cult at id: {id}");
    return cult;
  }
}
