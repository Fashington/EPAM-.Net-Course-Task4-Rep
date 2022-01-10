using System.Collections.Generic;

namespace DataAccess
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
