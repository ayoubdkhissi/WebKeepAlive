using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WebKeepAlive.Core.Constants;
using WebKeepAlive.Core.Interfaces;

namespace WebKeepAlive.Core.Services;
public class WorkerService : IWorkerService
{
    public bool IsRunning()
    {
        ServiceController service = new ServiceController(AppDefaults.SERVICE_NAME);
        return service.Status == ServiceControllerStatus.Running;
    }

    public void Start()
    {
        if (IsRunning())
            return;
        ServiceController service = new ServiceController(AppDefaults.SERVICE_NAME);
        service.Start();
    }

    public void Stop()
    {
        if (!IsRunning())
            return;
        
        ServiceController service = new ServiceController(AppDefaults.SERVICE_NAME);
        service.Stop();
    }
}
