using ClientBIN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace ClientBIN.Repository
{
    public class MyAppContextDb:DbContext
    {
        public  DbSet<BIN> BINs { get; set; }

        public MyAppContextDb(DbContextOptions options) : base(options)
        {

        }
        
    }
}
