using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Entities;

namespace WebKeepAlive.Core.Interfaces;
public interface IEndpointRepository
{
    Task<IEnumerable<Endpoint>> GetAllEndpointsAsync();
    Task<Endpoint> GetEndpointByIdAsync(int id);
    Task<Endpoint> AddEndpointAsync(Endpoint endpoint);
    Task<Endpoint> UpdateEndpointAsync(Endpoint endpoint);
    Task<Endpoint> DeleteEndpointAsync(int id);
}
