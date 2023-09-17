using Lesson21.JsonSettings.Policies;

namespace Lesson21.Tests.Tests.Unit.JsonSettings.Policies;

[TestFixture]
public class UpperCaseNamingPolicyTests
{
    private readonly UpperCaseNamingPolicy _policy = new UpperCaseNamingPolicy();

    [Test]
    public void ConvertNameTest()
    {
        var testData = "uppercase";
        var expectedResult = "UPPERCASE";

        var actualResult = _policy.ConvertName(testData);

        Assert.IsNotNull(actualResult, "Actial result is null");
        Assert.AreEqual(expectedResult, actualResult, "Expected and actial results are not equal");
    }
}
