using Lesson21.Jobs;
using Lesson21.Tests.Dummies.Logger;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21.Tests.Tests.Unit.Jobs;
public class SimpleJobTests
{
    private readonly LoggerMock<SimpleJob> _logger = new LoggerMock<SimpleJob>();
    private SimpleJob _job;

    [SetUp]
    public void Setup()
    {
        _job = new SimpleJob(_logger);
    }

    [Test]
    public async Task StartAsyncTest()
    {
        // Arrange
        var token = new CancellationToken();

        // Act
        await _job.StartAsync(token);
        await Task.Delay(2000);

        // Assert
        Assert.Greater(_logger.Memory.Count, 0);

        await _job.StopAsync(token);
    }

    [Test]
    public async Task StopAsyncTest()
    {
        var token = new CancellationToken();
        await _job.StartAsync(token);

        await _job.StopAsync(token);

        await Task.Delay(2000);

        var lastMsg = _logger.Memory.Last().ToString();

        Assert.AreEqual("Stop simple job", lastMsg);
    }

    [Test]
    public void DisposeTest()
    {
        Assert.Pass();
    }
}
