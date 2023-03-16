using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IExternalUserRole
    {
        Task<List<Roles>> GetRolesByUserId(int userId, string dbName);
        Task<List<Roles>> GetRolesByIds(string roleIDs, string dbName);
        Task<ExternalUserRole> GetUserRole(int userRoleId);
        Task<long> Post(ExternalUserRole userRoles, string dbName);
        Task<bool> Put(ExternalUserRole userRoles, string dbName);
        Task<List<Roles>> GetActiveUserRoles();
        Task<ExternalUserRole> GetUserRoleByID(int externalUserID);
    }
}
