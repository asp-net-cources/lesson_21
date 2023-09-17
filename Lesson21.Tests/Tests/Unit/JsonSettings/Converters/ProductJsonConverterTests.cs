using Lesson21.JsonSettings.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Lesson21.Tests.Tests.Unit.JsonSettings.Converters;

[TestFixture]
public class ProductJsonConverterTests
{
    private readonly ProductJsonConverter _converter = new ProductJsonConverter();

    [Test]
    public void ReadExceptionTest()
    {
        var json = "{}";

        Assert.Throws(
            typeof(JsonException),
            () =>
            {
                ReadOnlySpan<byte> bytes = Encoding.UTF8.GetBytes(json);
                Utf8JsonReader reader = new(bytes);
                reader.Read();
                _converter.Read(ref reader, typeof(object), new JsonSerializerOptions());
            }
        );
    }

    [Test]
    public void ReadValidTest()
    {
        var json = "{ \"ID\": 0, \"NAME\": \"string\", \"DESCRIPTION\": \"string\",  \"PRICE\": 0, \"PRODUCTTYPE\": \"Book\"}";

        Assert.DoesNotThrow(
            () =>
            {
                ReadOnlySpan<byte> bytes = Encoding.UTF8.GetBytes(json);
                Utf8JsonReader reader = new(bytes);
                reader.Read();
                _converter.Read(ref reader, typeof(object), new JsonSerializerOptions());
            }
        );
    }

    [Test]
    public void WriteTest()
    {
        Assert.Pass();
    }
}
