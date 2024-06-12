using Core;
using Core.Data;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repos
{
    public class DepartamentoRepo : IDepartamentoRepo
    {
        private readonly string _connectionString;
        public DepartamentoRepo(string dbConexion)
        {
            _connectionString = dbConexion;
        }
        public async Task<List<Departamento>> GetDepartamentosByIdEmpresa(int idEmpresa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { IdEmpresa = idEmpresa };
                string sql = "ObtenerDepartamentosPorIdEmpresa";

                var departamentos = await connection.QueryAsync<Departamento>(sql, parameters, commandType: CommandType.StoredProcedure);

                return departamentos.AsList();
            }
        }
    }
}
