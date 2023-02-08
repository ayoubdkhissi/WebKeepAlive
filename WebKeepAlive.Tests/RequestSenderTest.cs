using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Interfaces;
using WebKeepAlive.Core.Services;

namespace WebKeepAlive.Tests;
public class RequestSenderTest
{
    [Fact]
    public async Task SendRequestAsync()
    {
        var requestSender = new RequestSender();
        var result = await requestSender.SendRequestAsync("https://addressesapi.azurewebsites.net/api/addresses");
        Assert.True(result);
    }
}
