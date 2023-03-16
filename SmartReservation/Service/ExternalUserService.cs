
using Dapper;
using Dapper.Contrib.Extensions;
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
    public class ExternalUserService : IExternalUser
    {
        private readonly IConfiguration _config;
        public ExternalUserService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<ExternalUser> FindByNameAsync(string username)
        {
            const string sql = @"SELECT * FROM ExternalUser WHERE Email = @username";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<ExternalUser>(sql, new { username }).FirstOrDefault();
        }

        public async Task<ExternalUser> CreateAsync(ExternalUser user)
        {

            try
            {
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
                var userId = connection.Insert(user);
                user.ExternalUserID = (int)userId;
                return user;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<long> Post(ExternalUser user)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Insert(user);
        }


        public async Task<bool> PutUpdateAsync(ExternalUser user)
        {
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return await connection.UpdateAsync(user);
        }

        public async Task<ExternalUser> FindByIdAsync(int UserID)
        {
            const string sql = "SELECT * FROM ExternalUser WHERE ExternalUserID = @UserID";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.QueryFirstOrDefault<ExternalUser>(sql, new { UserID });
        }


        public async Task<List<ExternalUser>> GetAllUsersInclLockedOut()
        {
            const string sql = "SELECT ExternalUserID, Username, FirstName, LastName, LockoutEnabled FROM ExternalUser ORDER BY FirstName, LastName";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<ExternalUser>(sql).ToList();
        }

        public async Task<List<ExternalUserModel>> GetUserWithRoles()
        {
            const string sql = "EXEC proc_ExternalUsers_StringAgg";
            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<ExternalUserModel>(sql).ToList();
        }
        public async Task<ExternalUser> CheckIfEmailExist(string email)
        {
            try
            {
                const string sql = "EXEC proc_Externaluser_CheckIfRegistrationExist @email";
                var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
                return connection.Query<ExternalUser>(sql, new { email = email }).FirstOrDefault();
            }
            catch (Exception r)
            {

                throw;
            }
        }

        public async Task<ExternalUserModel> FindByExternalUserID(int externalUserID)
        {
            string sql =
                        @"SELECT 
                            EU.FirstName,
                            EU.LastName,
	                        EU.Email,
	                        EU.UserName,
	                        EU.PhoneNumber,
                            R.RoleID,
	                        R.RoleName AS UserRole,
	                        EU.LockoutEnabled,
                            EU.PasswordHash,
                            EU.ExternalUserID,
                            EU.SecurityStamp,
                            EU.PhoneNumberConfirmed,
                            EU.EmailConfirmed,
                            EU.AccessFailedCount,
                            EU.LockoutEndDateUtc
                        FROM ExternalUser EU
                        INNER JOIN ExternalUserRole EUR ON EUR.ExternalUserID = EU.ExternalUserID
                        INNER JOIN Roles R ON R.RoleID = EUR.RoleID
                        WHERE EU.ExternalUserID = @externalUserID";

            var connection = Connection.GetOpenConnection(_config.GetConnectionString("Recipe"));
            return connection.Query<ExternalUserModel>(sql, new { externalUserID = externalUserID }).FirstOrDefault();
        }

    }
}
