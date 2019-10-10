using CM.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CM.Data.ModelConfigurations
{
    public class TicketModelConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketModelConfiguration()
        {
            this.HasKey(t => t.Id);
            this.HasRequired(t => t.Projection)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.ProjectionId);
            this.HasOptional(t => t.Reservation);
        }
    }
}