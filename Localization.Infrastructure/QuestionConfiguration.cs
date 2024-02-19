using Localization.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Localization.Infrastructure;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable(nameof(Question));
        builder.HasKey(x => x.Id);

        builder.HasI18n(x => x.Title);
        builder.Property(x => x.Description);
    }
}