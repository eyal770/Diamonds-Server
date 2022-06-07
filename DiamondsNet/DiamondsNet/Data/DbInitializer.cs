using DiamondsAPI.Models;
using System.Linq;

namespace DiamondsAPI.Data
{
    public class DbInitializer
    {

        public static void Initialize(DiamondContext context)
        {
            context.Database.EnsureCreated();
            ;

            if (context.Diamonds.Any())
            {
                return;   // DB has been seeded
            }

            var DiamondArr = new Diamond[]
            {
                new Diamond ("Round",1.02m,"D","IF",15000,18000),
                new Diamond ("Pear",1.5m,"E","VVS1",20000,21000),
                new Diamond ("Emerald",0.95m,"G","VVS2",12000,10000),
                new Diamond ("Round",2.15m,"F","I2",50000,55000),
                new Diamond ("Emerald",0.5m,"D","IF",2000,3000),
                new Diamond ("Pear",1.2m,"G","I1",15000,12000)
            };

            context.Diamonds.AddRange(DiamondArr);
            context.SaveChanges();
        }
    }
}
