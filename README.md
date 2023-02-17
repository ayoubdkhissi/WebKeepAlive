# WEB KEEP ALIVE
A basic background service that periodically sends HTTP requests to infrequently visited websites to keep them active. The service is administered using a Desktop Application



This solution consists of two components: a **Windows Service** and a **Desktop Application** for monitoring and controlling the service. The Desktop Application provides functionality for adding and removing websites you want to keep active, and starting and stopping the Windows Service.

### Features:

- Adds unlimited number of websites to the list.
- Sends HTTP GET requests to the websites **every 30 minutes**.
- User-friendly interface for easy administration.

### Notes:

- This first release of the application has a fixed send rate of 30 minutes.
While it is possible to make the send rate dynamic (i.e. allowing the user to specify the frequency of requests in minutes or seconds), this feature has not been included in this release to avoid potential misuse (e.g. as a tool for conducting a DOS attack).
- The primary use case for this application is for keeping websites hosted on free Cloud tiers alive, such as Azure App Services.
It is important to note that many free cloud services have limits on daily processing power usage, and sending a high number of requests in a short period of time may result in additional charges from the cloud provider.
- When adding URLs to the list of websites to keep active, it is recommended to choose an endpoint that does not consume a significant amount of processing power. This helps to minimize resource usage on your server. If the website's home page is feature-rich and requires access to a database, consider adding a simpler page such as the "About" or "Privacy" page, or creating a dedicated endpoint specifically for this purpose.
- Future releases may include the dynamic send rate feature after further study and consideration.




# Installation Steps

1. Download the latest release of the application from <a href="https://github.com/ayoubdkhissi/WebKeepAlive/releases/download/First_Release/WebKeepAlive.rar">here</a>. Store the folder in a safe place.
2. Open a PowerShell with administrator privileges.
3. Use the following command to create a Windows Service:

``
sc.exe Create WebKeepAliveService binPath= "path to the downloaded WebKeepAlive.Service.exe"
``

Example:
 
![image](https://user-images.githubusercontent.com/73041562/218685570-52b70606-4745-43e5-be8d-b66fc4be58cd.png)

4.  Run the WebKeepAlive.UI (as admin) and you can start, stop, add and delete websites from there.

![image](https://user-images.githubusercontent.com/73041562/218685728-15291d58-16a5-434b-af92-73e343b124e3.png)
![image](https://user-images.githubusercontent.com/73041562/218685886-47ffa9a4-2f89-4994-b33a-d3bb09bdaf20.png)



To verify that the service is installed, you can check for WebKeepAliveService in the list of services in the Windows Control Panel. From there, you can also start, stop the service, and set it to start automatically on system startup.

![image](https://user-images.githubusercontent.com/73041562/218686103-c0909d80-dbfc-4c60-b8ef-e32a02cc13fa.png)




**Notes**:

When running the service, a folder named WebKeepAlive will be created at `C:/WebKeepAlive`, containing an SQLite database as well as a folder for logs. If you want to monitor the progress of sending requests or any potential issues, you can review the logs within this folder.

![image](https://user-images.githubusercontent.com/73041562/218686263-1ecdac9d-1e92-4eef-a620-c2d2eeac60e6.png)



Note that the published application is not self-contained, and therefore requires the **.NET runtime** to be installed for both the service and the user interface to function properly


# Development 
If you plan to run the project in Visual Studio and continue development, keep in mind the following points:
- When starting or stopping the service, make sure to use an absolute path to the generated bin/Debug/net6.0/WebKeepAlive.Service.exe file, during the development process.

Use this: 

```
...

var start_info = new ProcessStartInfo
{
    FileName = @" Path_to_project\WebKeepAlive.Service\bin\Debug\net6.0\WebKeepAlive.Service.exe",
    UseShellExecute = true,
    CreateNoWindow = true
};
var starting_result = Process.Start(start_info);
...

```

instead of this: 
```
...
        ServiceController service = new ServiceController(AppDefaults.SERVICE_NAME);
        
        service.Stop();
...
        
```

- If you plan to start or stop the Windows service (not just the generated executable), you will need to run Visual Studio as an administrator. Additionally, admin privileges are required for unit tests to pass.


