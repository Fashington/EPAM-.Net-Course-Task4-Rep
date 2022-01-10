using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataOperations
{
    public class DataOperations : IOperations
    {
        public void Clear()
        {
            using (var context = new DataDbContext())
            {
                Console.WriteLine("Start point for clearing db");
                context.Database.ExecuteSqlCommand("DELETE FROM Sales");
                context.Database.ExecuteSqlCommand("DELETE FROM Managers");
                Console.WriteLine("End point for clearing db");
            }
        }

        public async Task<Manager> AddManagerAsync(string managerName)
        {
            using (var context = new DataDbContext())
            {
            var selectManager = from m in context.Managers
                                where m.Name == managerName
                                select m;

                if (!selectManager.Any())
                {
                    var manager = new Manager()
                    {
                        Name = managerName
                    };

                    context.Managers.Add(manager);
                    await Task.Run(() => context.SaveChangesAsync());
                    return manager;
                }
                else
                {
                    return selectManager.First();
                }
            }
        }

        public async Task AddSaleAsync(Manager manager, DateTime date, string client, string item, double cost)
        {
            using (var context = new DataDbContext())
            {
                var sale = new Sale()
                {
                    ManagerId = manager.ManagerId,
                    Date = date,
                    Client = client,
                    Item = item,
                    Cost = cost
                };

                context.Sales.Add(sale);
                await Task.Run(() => context.SaveChangesAsync());
            }
        }
    }
}
