using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataOperations
{
    interface IOperations
    {
        Task<Manager> AddManagerAsync(string managerName);
        Task AddSaleAsync(Manager manager, DateTime date, string client, string item, double cost);
        void Clear();
    }
}
