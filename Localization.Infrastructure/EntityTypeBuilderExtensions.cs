using System.Linq.Expressions;
using Localization.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Localization.Infrastructure;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> HasI18n<TEntity>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, IEnumerable<I18nValue.CultureAndValue>?>> keyExpression)
        where TEntity : class
    {
        builder.OwnsMany(keyExpression, navigationBuilder =>
        {
            navigationBuilder.ToJson();
            navigationBuilder.Property(x => x.Culture);
            navigationBuilder.Property(x => x.Value);
        });
        
        return builder;
    }
}