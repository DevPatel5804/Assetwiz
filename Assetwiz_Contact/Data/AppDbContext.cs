using Microsoft.EntityFrameworkCore;
using Assetwiz_Contact.ViewModels;
using Assetwiz_Contact.Controllers;

namespace Assetwiz_Contact.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Assetwiz_Contact.ViewModels.ContactViewModel> Contact { get; set; }

        public DbSet<Assetwiz_Contact.ViewModels.ContactPersonViewModel> ContactPerson { get; set; }

        public DbSet<Assetwiz_Contact.ViewModels.ContactFilesViewModel> ContactFiles { get; set; }

        public DbSet<Assetwiz_Contact.ViewModels.SchedulersViewModel> Scheduler { get; set; }
         public DbSet<Assetwiz_Contact.ViewModels.SchedulerConfigViewModel> SchedulerConfig { get; set; }
         public DbSet<Assetwiz_Contact.ViewModels.LocationViewModel> Location { get; set; }
         public DbSet<Assetwiz_Contact.ViewModels.LocationConfigViewModel> LocationConfig { get; set; }
         public DbSet<Assetwiz_Contact.ViewModels.GroupConfigViewModel> Groups { get; set; }

         public DbSet<Assetwiz_Contact.ViewModels.ProductTransactionConfigViewModel> ProductTransaction { get; set; }
         

    }
}
