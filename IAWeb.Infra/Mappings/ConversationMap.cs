using IAWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace IAWeb.Infra.Mappings
{
    public class ConversationMap : EntityTypeConfiguration<Conversation>
    {
        public ConversationMap()
        {
            ToTable("Conversation");
            HasKey(x => x.Id);
            Property(x => x.Question).IsRequired().HasMaxLength(250);
            Property(x => x.Answer).IsRequired().HasMaxLength(250);
        }
    }
}
