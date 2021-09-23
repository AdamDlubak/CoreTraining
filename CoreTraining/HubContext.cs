using CoreTraining.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreTraining
{
    public class HubContext : DbContext
    {
        public IConfiguration Configuration { get; }
        
        public virtual DbSet<Activity> Activity { get; set; }

        public HubContext(IConfiguration configuration, DbContextOptions<HubContext> options) : base(options)
        {
            Configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Configuration.GetConnectionString("HubDatabase");

            optionsBuilder.UseSqlServer(connection);
        }
        
    }
}
