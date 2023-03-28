using instaCult.Interfaces;

namespace instaCult.Repositories;

public class CultMembersRepository : IRepository<CultMember, int>
{
  private readonly IDbConnection _db;

  public CultMembersRepository(IDbConnection db)
  {
    _db = db;
  }

  public CultMember Create(CultMember cultMemberData)
  {
    string sql = @"
    INSERT INTO cultmembers
    (accountId, cultId)
    VALUES
    (@accountId, @cultId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, cultMemberData);
    cultMemberData.CreatedAt = DateTime.Now; // NOTE how to get NOW in datetime;
    cultMemberData.Id = id;
    return cultMemberData;
  }

  public List<CultMember> Get()
  {
    throw new NotImplementedException();
  }

  public CultMember GetOne(int id)
  {
    throw new NotImplementedException();
  }

  public int Remove(int id)
  {
    throw new NotImplementedException();
  }

  public int Update(CultMember updateData)
  {
    throw new NotImplementedException();
  }

  internal List<Cultist> GetCultists(int cultId)
  {
    string sql = @"
      SELECT
      cm.*,
      acct.*
      FROM cultmembers cm
      JOIN accounts acct ON cm.accountId = acct.id
      WHERE cm.cultId = @cultId;
    ";
    List<Cultist> cultists = _db.Query<CultMember, Cultist, Cultist>(sql, (cm, cultist) =>
    {
      cultist.CultMemberId = cm.Id;
      return cultist;
    }, new { cultId }).ToList();
    return cultists;
  }

  internal List<CultMembership> GetCultMemberships(string userId)
  {
    string sql = @"
    SELECT
    cm.*,
    c.*,
    leader.*
    FROM cultmembers cm
    JOIN cults c ON cm.cultId = c.id
    JOIN accounts leader ON c.leaderId = leader.id
    WHERE cm.accountId = @userId;
    ";
    List<CultMembership> memberships = _db.Query<CultMember, CultMembership, Profile, CultMembership>(sql, (cm, cultM, prof) =>
    {
      cultM.CultMemberId = cm.Id;
      cultM.Leader = prof;
      return cultM;
    }, new { userId }).ToList();
    return memberships;
  }
}
