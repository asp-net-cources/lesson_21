using System.Diagnostics.Metrics;

namespace Lesson21.Tests;

[TestFixture]
public class SimpleTests
{
    private int _setupCounter = 0;
    private int _tearDownCounter = 0;
    private int _testCounter = 0;
    private IList<string> _database;

    [OneTimeSetUp]
    public void OneTimeSetUp() {
        _database = new List<string>();
    }

    [SetUp]
    public void Setup() {
        _database.Add($"Setup: {_setupCounter++}");
    }

    [Test]
    public void Test1() {
        _database.Add($"Test1: {_testCounter++}");
        Assert.Pass();
    }

    [Test]
    public void Test2() {
        _database.Add($"Test2: {_testCounter++}");
        Assert.Pass();
    }

    [Test]
    public void Test3() {
        _database.Add($"Test3: {_testCounter++}");
        Assert.Pass();
    }

    [TearDown]
    public void TearDown() {
        _database.Add($"TearDown: {_tearDownCounter++}");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() {
        _database = null;
    }
}
