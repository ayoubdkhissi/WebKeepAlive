using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Interfaces;

namespace WebKeepAlive.Core.Services;
public class RequestSender : IRequestSender
{
    public async Task<bool> SendRequestAsync(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);

        return response.IsSuccessStatusCode;
    }
}
