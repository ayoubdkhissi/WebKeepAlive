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
    private readonly ILogger<KeepAliveWorker> _logger;

    public KeepAliveWorker(IEndpointRepository endpointRepository, 
        IRequestSender requestSender, 
        ILogger<KeepAliveWorker> logger)
    {
        _endpointRepository = endpointRepository;
        _requestSender = requestSender;
        _logger = logger;
    }

    public async Task Invoke()
    {
        _logger.LogInformation("===================================================================");
        _logger.LogInformation("Task Invoked");
        var endpoints = await _endpointRepository.GetAllEndpointsAsync();
        
        foreach(var endpoint in endpoints)
        {
            _logger.LogInformation($"Sending Request to {endpoint.EndpointUrl} ...");
            var result = await _requestSender.SendRequestAsync(endpoint.EndpointUrl);
            
            if(result)
            {
                endpoint.successCount++;
                _logger.LogInformation($"Successfully sent request to {endpoint.EndpointUrl}");
            }
            else
            {
                endpoint.failureCount++;
                // log that the request sending has failled
                _logger.LogInformation($"Failed to send request to {endpoint.EndpointUrl}");

            }

            await _endpointRepository.UpdateEndpointAsync(endpoint);
        }

        _logger.LogInformation("Task Completed");

    }
}
