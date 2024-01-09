
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace TodoApi.Models
{
    public class CommerceContext : DbContext
    {
        //internal object DbPath;
        public string DbPath { get; }

        public CommerceContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "enozomdb.db"); /////////
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=LAPTOP-1RSS93C8\SQLEXPRESS;Database=EnozomDB;Trusted_connection=True;trustservercertificate=true"); //trust server solve the problem of not trusted authority 
        }
    }
}































