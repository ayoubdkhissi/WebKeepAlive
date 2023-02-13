using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Interfaces;
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
        if (service.IsRunning())
            service.Stop();
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
        if (!service.IsRunning())
            service.Start();
        service.Stop();

        // Assert
        Assert.False(service.IsRunning());
    }
}
