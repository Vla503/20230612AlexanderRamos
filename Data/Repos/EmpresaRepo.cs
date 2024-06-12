using Core;
using Core.Data;
using Dapper;
using System.Data.SqlClient;

namespace Data.Repos
{
    public class EmpresaRepo : IEmpresaRepo
    {
        private readonly string _connectionString;
        public EmpresaRepo(string dbConexion)
        {
            _connectionString = dbConexion;
        }

        public async Task<Empresa> GetEmpresaAsync(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { ID = Id };
                var sql = "EXEC sp_ObtenerEmpresaPorID @ID";

                var empresa = await connection.QueryFirstOrDefaultAsync<Empresa>(sql, parameters);

                if (empresa == null)
                {
                    throw new KeyNotFoundException("Empresa no encontrada");
                }

                return empresa;
            }
        }

        public async Task RegistrarUpdateEmpresaAsync(Empresa empresa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", empresa.ID);
                parameters.Add("@Nombre", empresa.Nombre);
                parameters.Add("@RazonSocial", empresa.RazonSocial);
                parameters.Add("@FechaRegistro", empresa.FechaRegistro);
                parameters.Add("@LogDetails", empresa.LogDetails);

                await connection.ExecuteAsync("sp_RegistrarEmpresa", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
