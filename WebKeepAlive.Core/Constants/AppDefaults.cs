using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebKeepAlive.Core.Constants;
public static class AppDefaults
{
    public const string APP_NAME = "WebKeepAlive";
    public const string SERVICE_NAME = "WebKeepAliveService";
    private const string DATABASE_NAME = "WebKeepAlive_database.db";

    public static string AppDataFolder => GetAppDataFolder();
    private static string _appDataFolder;
    public static string DatabasePath => Path.Combine(AppDataFolder, DATABASE_NAME);


    public static string LogDataFolder => Path.Combine(GetAppLogsFolder(), "log - Date .txt");

    private static string GetAppLogsFolder()
    {
        return Path.Combine(GetAppDataFolder(), "logs");
    }

    private static string GetAppDataFolder()
    {
        if (_appDataFolder is not null)
            return _appDataFolder;

        // Get all drives
        var drives = Directory.GetLogicalDrives();

        // search for C drive
        string c_drive = drives.FirstOrDefault(c => c.Contains('C'));

        // if exist and you have access to it, create a folder called APP_NAME and put DB in it
        if (c_drive is not null && IsDirectoryWritable(c_drive))
        {
            _appDataFolder = Path.Combine(c_drive, APP_NAME);
            Directory.CreateDirectory(_appDataFolder);
            return _appDataFolder;
        }

        foreach (var drive in drives)
        {
            if (IsDirectoryWritable(drive))
            {
                _appDataFolder = Path.Combine(drive, APP_NAME);
                return _appDataFolder;
            }
        }

        // if we get here it means that we couldn't create the APP data folder
        Environment.Exit(0);


        return _appDataFolder;
    }


    private static bool IsDirectoryWritable(string dirPath)
    {
        try
        {
            // Attempt to get a list of security permissions from the folder. 
            // This will raise an exception if the path is read only or do not have access to view the permissions. 
            System.Security.AccessControl.DirectorySecurity ds = (new DirectoryInfo(dirPath).GetAccessControl());
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
    }
}
