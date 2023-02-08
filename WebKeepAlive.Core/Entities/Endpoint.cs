using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebKeepAlive.Core.Entities;
public class Endpoint
{
    public int Id { get; set; }

    public string EndpointUrl { get; set; }

    public int successCount { get; set; }

    public int failureCount { get; set; }
}
