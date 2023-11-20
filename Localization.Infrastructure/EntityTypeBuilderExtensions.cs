using System.Linq.Expressions;
using Localization.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Localization.Infrastructure;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> HasLocalization<TEntity>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, IEnumerable<LocalizedString.CultureAndValue>?>> keyExpression,
        string name)
        where TEntity : class
    {
        builder.OwnsMany(keyExpression, navigationBuilder =>
        {
            navigationBuilder.ToTable($"Localize_{typeof(TEntity).Name}_{name}");
            navigationBuilder.Property(x => x.Culture);
            navigationBuilder.Property(x => x.Value);
        });
        builder.Navigation(keyExpression).AutoInclude(false);
        
        return builder;
    }
}