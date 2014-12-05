namespace Axh.Core.DbContexts.WeddingContext.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Axh.Core.DomainModels.Wedding;

    public class RsvpStoryMap : EntityTypeConfiguration<RsvpStory>
    {
        public RsvpStoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("Wedding_RsvpStories");

            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.StoryTitle).HasColumnName("StoryTitle").HasMaxLength(64);
            this.Property(x => x.StoryBody).HasColumnName("StoryBody").HasColumnType("text");
            this.Property(x => x.StorySubject).HasColumnName("StorySubject");

            this.HasRequired(x => x.Rsvp).WithMany(x => x.Stories);

        }
    }
}
