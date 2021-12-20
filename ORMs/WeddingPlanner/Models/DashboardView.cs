using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class DashboardView
    {
        public string UserName { get; set; }
        public List<Wedding> AllWeddings { get; set; }
    }
}