using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IRole
    {
        Task<List<Roles>> GetRolesByUserId(int userId, string dbName);
        Task<List<Roles>> GetRolesByIds(string roleIDs, string dbName);
    }
}
