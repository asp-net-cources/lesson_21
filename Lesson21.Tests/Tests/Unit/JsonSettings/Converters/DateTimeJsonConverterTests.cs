using Lesson21.JsonSettings.Converters;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson21.Tests.Tests.Unit.JsonSettings.Converters;

[TestFixture]
public class DateTimeJsonConverterTests
{
    private readonly DateTimeJsonConverter _converter = new DateTimeJsonConverter();

    [Test]
    public void ReadTest()
    {
        // Arrange
        var expectedDate = new DateTime(1987, 2, 1, 23, 32, 00);
        var date = "\"01/02/1987 23:32\"";
        ReadOnlySpan<byte> bytes = Encoding.UTF8.GetBytes(date);
        Utf8JsonReader reader = new(bytes);
        reader.Read();

        // Act
        var actualDate = _converter.Read(ref reader, typeof(object), new JsonSerializerOptions());

        // Assert
        Assert.AreEqual(expectedDate, actualDate);
    }

    [Test]
    public void WriteTest()
    {
        Assert.Pass();
    }
}
