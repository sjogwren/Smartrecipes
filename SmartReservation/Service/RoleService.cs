
using Dapper;
using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class RoleService : IRole
    {
        private readonly IConfiguration _config;
        public RoleService(IConfiguration configuration) { _config = configuration; }

        public async Task<List<Roles>> GetRolesByUserId(int userId, string dbName)
        {
            const string sql = @"SELECT R.* FROM Users U
            INNER JOIN UserRoles UR ON UR.UserID = U.UserID
            INNER JOIN Roles R ON R.RoleID = UR.RoleID
            WHERE U.UserID = @UserID AND DeletedOn IS NULL ORDER BY RoleName";

            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Roles>(sql, new { userId }).ToList();
        }

        public async Task<List<Roles>> GetRolesByIds(string roleIDs, string dbName)
        {
            var sql = $"SELECT * FROM Roles WHERE RoleID IN ({roleIDs})";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<Roles>(sql).ToList();
        }
    }
}
