using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Periods;
using CentsTrail.Api.Models.Periods.AddPeriod;
using CentsTrail.Api.Models.Periods.UpdatePeriod;
using Dapper;

namespace CentsTrail.Api.DataAccess.Periods
{
  public class PeriodsRepository : BaseRepository, IPeriodsRepository
  {
    private const string AddPeriodStoredProcedure = "dbo.AddPeriod";
    private const string UpdatePeriodStoredProcedure = "dbo.UpdatePeriod";
    private const string DeletePeriodStoredProcedure = "dbo.DeletePeriod";
    private const string GetPeriodStoredProcedure = "dbo.GetPeriod";

    public PeriodsRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<long> AddPeriod(string userId, AddPeriodRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@StartDate", request.StartDate, DbType.DateTime, ParameterDirection.Input);
      parameters.Add("@EndDate", request.EndDate, DbType.DateTime, ParameterDirection.Input);

      parameters.Add("@Id", dbType: DbType.Int64, direction: ParameterDirection.Output);

      await Database.ExecuteAsync(AddPeriodStoredProcedure, parameters, commandType: CommandType.StoredProcedure);

      return parameters.Get<long>("@Id");
    }

    public async Task<bool> DeletePeriod(string userId, long periodId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", periodId, DbType.Int64, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(DeletePeriodStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }

    public async Task<IEnumerable<Period>> GetPeriods(string userId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      return await Database.QueryAsync<Period>(GetPeriodStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<Period> GetPeriod(string userId, long periodId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", periodId, DbType.Int64, ParameterDirection.Input);

      return await Database.QueryFirstOrDefaultAsync<Period>(GetPeriodStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdatePeriod(string userId, long periodId, UpdatePeriodRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Id", periodId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@StartDate", request.StartDate, DbType.DateTime, ParameterDirection.Input);
      parameters.Add("@EndDate", request.EndDate, DbType.DateTime, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(UpdatePeriodStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }
  }
}