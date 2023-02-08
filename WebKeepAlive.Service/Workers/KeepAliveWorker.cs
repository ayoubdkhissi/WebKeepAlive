using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Interfaces;

namespace WebKeepAlive.Service.Workers;
public class KeepAliveWorker : IInvocable
{
    private readonly IEndpointRepository _endpointRepository;
    private readonly IRequestSender _requestSender;

    public KeepAliveWorker(IEndpointRepository endpointRepository, IRequestSender requestSender)
    {
        _endpointRepository = endpointRepository;
        _requestSender = requestSender;
    }

    public async Task Invoke()
    {
        Console.WriteLine("Task Invoked");
        var endpoints = await _endpointRepository.GetAllEndpointsAsync();
        
        foreach(var endpoint in endpoints)
        {
            Console.WriteLine($"Sending Request to {endpoint.EndpointUrl} ...");
            var result = await _requestSender.SendRequestAsync(endpoint.EndpointUrl);
            
            if(result)
                endpoint.successCount++;
            else
                endpoint.failureCount++;

            await _endpointRepository.UpdateEndpointAsync(endpoint);
        }

        Console.WriteLine("Task Completed");
    }
}
