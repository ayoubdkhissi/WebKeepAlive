using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Entities;
using WebKeepAlive.Core.Interfaces;

namespace WebKeepAlive.Core.Data;
public class EndpointRepository : IEndpointRepository
{
    private readonly AppDbContext _appDbContext;

    public EndpointRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Endpoint> AddEndpointAsync(Endpoint endpoint)
    {
        try
        {
            _appDbContext.Endpoints.Add(endpoint);
            await _appDbContext.SaveChangesAsync();

        }
        catch (Exception)
        {
            return null;
        }
        return endpoint;
    }

    public async Task<Endpoint> DeleteEndpointAsync(int id)
    {
        var endPoint = await _appDbContext.Endpoints.FindAsync(id);
        _appDbContext.Endpoints.Remove(endPoint);
        await _appDbContext.SaveChangesAsync();
        return endPoint;
    }

    public async Task<IEnumerable<Endpoint>> GetAllEndpointsAsync()
    {
        return await _appDbContext.Endpoints.ToListAsync();
    }

    public async Task<Endpoint> GetEndpointByIdAsync(int id)
    {
        return await _appDbContext.Endpoints.FindAsync(id);
    }

    public async Task<Endpoint> UpdateEndpointAsync(Endpoint endpoint)
    {
        try
        {
            var entry = _appDbContext.Endpoints.Update(endpoint);
            await _appDbContext.SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
