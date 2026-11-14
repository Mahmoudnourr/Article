using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Blocks.EntityFrameWork;

public static class builderExtentions
{
    public static PropertyBuilder<T> HasEnumConversion<T>(this PropertyBuilder<T> propertyBuilder) where T :  Enum
    {
         return propertyBuilder.HasConversion(
                v => v.ToString(),
                v => (T)Enum.Parse(typeof(T), v)
            ).IsRequired().HasMaxLength(50);
    }
    public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) 
    {
       return propertyBuilder.HasConversion(buildJsonListConvertor<T>());
    }
    public static ValueConverter<TCollection, string> buildJsonListConvertor<TCollection>()
    {
        Func<TCollection, string> SerializeFunction = v => JsonSerializer.Serialize(v);
        Func<string, TCollection> DeserializeFunction = v => JsonSerializer.Deserialize<TCollection>(v??"[]")!;
        return new ValueConverter<TCollection, string>
            (
          v=>SerializeFunction(v),
           v=> DeserializeFunction(v)
        );

    }
}
