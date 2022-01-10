using System;

namespace DataAccess
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Item { get; set; }
        public double Cost { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
