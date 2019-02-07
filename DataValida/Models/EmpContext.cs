using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DataValida.Models
{

    public class EmpContext:DbContext
    {
        public EmpContext():base("Conn")
        {

        }
        public DbSet<EmpDetail> EmpDetails { get; set; }
    }
}