
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Service
{

    public class ExternalUserRoleService : IExternalUserRole
    {
        private readonly IConfiguration _config;
        public ExternalUserRoleService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<Roles>> GetRolesByUserId(int userId, string dbName)
        {
            const string sql = @"SELECT R.* FROM ExternalUser U
                                    INNER JOIN ExternalUserRole UR ON UR.ExternalUserID = U.ExternalUserID
                                    INNER JOIN Roles R ON R.RoleID = UR.RoleID
                                    WHERE U.ExternalUserID = @UserID AND DeletedOn IS NULL ORDER BY Role";

            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Roles>(sql, new { userId }).ToList();
        }

        public async Task<List<Roles>> GetRolesByIds(string roleIDs, string dbName)
        {
            var sql = $"SELECT * FROM Roles WHERE RoleID IN ({roleIDs})";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Roles>(sql).ToList();
        }

        public async Task<ExternalUserRole> GetUserRole(int userRoleId)
        {
            const string sql = "SELECT * FROM ExternalUserRole WHERE ExternalUserRoleID = @userRoleId";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.QueryFirstOrDefault<ExternalUserRole>(sql, new { userRoleId });
        }

        public async Task<long> Post(ExternalUserRole userRoles, string dbName)
        {
            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
                return connection.Insert(userRoles);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<bool> Put(ExternalUserRole userRoles, string dbName)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Update(userRoles);

        }

        public async Task<List<Roles>> GetActiveUserRoles()
        {
            const string sql = "SELECT * FROM Roles WHERE RoleID IN (1,2)";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Roles>(sql).ToList();
        }

        public async Task<ExternalUserRole> GetUserRoleByID(int externalUserID)
        {
            const string sql = "SELECT * FROM ExternalUserRole WHERE ExternalUserID = @externalUserID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.QueryFirstOrDefault<ExternalUserRole>(sql, new { externalUserID });
        }
    }
}
