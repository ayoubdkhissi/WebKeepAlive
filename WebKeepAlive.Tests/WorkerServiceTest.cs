using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Services;

namespace WebKeepAlive.Tests;
public class WorkerServiceTest
{

    [Fact]
    public void ServiceShouldBeRunning()
    {
        // Arrange
        var service = new WorkerService();

        // Act
        service.Start();

        // Assert
        Assert.True(service.IsRunning());
    }

    [Fact]
    public void ServiceShouldBeStopped()
    {
        // Arrange
        var service = new WorkerService();

        // Act
        service.Stop();

        // Assert
        Assert.False(service.IsRunning());
    }

    [Fact]
    public void ServiceShouldBeStoppedAfterStart()
    {
        // Arrange
        var service = new WorkerService();

        // Act
        service.Start();
        service.Stop();

        // Assert
        Assert.False(service.IsRunning());
    }

    [Fact]
    public void ServiceShouldBeRunningAfterStop()
    {
        // Arrange
        var service = new WorkerService();

        // Act
        service.Stop();
        service.Start();

        // Assert
        Assert.True(service.IsRunning());
    }

    [Fact]
    public void ServiceShouldKeepRunningAfterStart()
    {
        // Arrange
        var service = new WorkerService();

        // Act
        service.Stop();
        service.Start();
        service.Start();

        // Assert
        Assert.True(service.IsRunning());
    }

    [Fact]
    public void ServiceShouldKeepStoppedAfterStop()
    {
        // Arrange
        var service = new WorkerService();

        // Act
        service.Start();
        service.Stop();
        service.Stop();

        // Assert
        Assert.False(service.IsRunning());
    }


}
