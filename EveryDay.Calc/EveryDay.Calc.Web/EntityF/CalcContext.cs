using EveryDay.Calc.Web.Repository;
using EveryDay.Calc.Webcalc.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EveryDay.Calc.Webcalc.EntitiF
{
    public class CalcContext : DbContext
    {
        public CalcContext()
            : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Calc\EveryDay.Calc\EveryDay.Calc.Webcalc\App_Data\calc.mdf;Integrated Security=True")
        {
        }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperResult> OperationResults { get; set; }

        public DbSet<User> User { get; set; }
    }
}