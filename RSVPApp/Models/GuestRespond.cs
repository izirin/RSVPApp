using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace RSVPApp.Models
{
    public class RSVPContext : DbContext
    {
        public RSVPContext(){}
        public RSVPContext(DbContextOptions<RSVPContext> options) : base(options)
        {

        }
        public DbSet<GuestRespond> GuestRespond { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=JRFZN53;Database=RSVP;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

    }
    public class GuestRespond
    {
        public int GuestRespondId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify whether you will attend")]
        public bool? Attend { get; set; }

    }
}
