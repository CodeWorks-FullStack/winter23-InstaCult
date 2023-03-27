using instaCult.Interfaces;

namespace instaCult.Repositories;

public class CultsRepository : IRepository<Cult, int>
{

  private readonly IDbConnection _db;

  public CultsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Cult Create(Cult cultData)
  {
    string sql = @"
      INSERT INTO cults
      (name, description, category, leaderId)
      VALUES
      (@name, @description, @category, @leaderId);
      SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, cultData);
    cultData.Id = id;
    return cultData;
  }

  public List<Cult> Get()
  {
    string sql = @"
    SELECT 
    c.*,
    lead.*
    FROM cults c
    JOIN accounts lead ON c.leaderId = lead.id;
    ";
    List<Cult> cults = _db.Query<Cult, Profile, Cult>(sql, (cult, leader) =>
    {
      cult.Leader = leader;
      return cult;
    }).ToList();
    return cults;
  }

  public Cult GetOne(int id)
  {
    string sql = @"
    SELECT 
    c.*,
    lead.*
    FROM cults c
    JOIN accounts lead ON c.leaderId = lead.id
    WHERE c.id = @id;
    ";
    Cult cult = _db.Query<Cult, Profile, Cult>(sql, (cult, leader) =>
    {
      cult.Leader = leader;
      return cult;
    }, new { id }).FirstOrDefault();
    return cult;
  }

  public int Remove(int id)
  {
    throw new NotImplementedException();
  }

  public int Update(Cult updateData)
  {
    throw new NotImplementedException();
  }
}
