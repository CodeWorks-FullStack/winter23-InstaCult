namespace instaCult.Interfaces;

public interface IRepository<T, Tid>
{
  public List<T> Get();

  public T GetOne(Tid id);

  public T Create(T data);
  public int Update(T updateData);

  public int Remove(Tid id);
}
