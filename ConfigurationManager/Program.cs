// Singleton ConfigurationManager class
public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private string loggingMode;
    private string databaseConnection;

    private ConfigurationManager()
    {
        // Private constructor to prevent instantiation
    }

    // Singleton instance property
    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    // Property for logging mode
    public string LoggingMode
    {
        get { return loggingMode; }
        set
        {
            loggingMode = value;
            Console.WriteLine($"Logging mode set to: {value}");
        }
    }

    // Property for database connection
    public string DatabaseConnection
    {
        get { return databaseConnection; }
        set
        {
            databaseConnection = value;
            Console.WriteLine($"Database connection set to: {value}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage of ConfigurationManager

        // Accessing the singleton instance
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Setting and retrieving configuration settings
        configManager.LoggingMode = "Verbose";
        configManager.DatabaseConnection = "Server=localhost;Database=mydatabase;User=myuser;Password=mypassword;";

        // Accessing the same instance from another part of the program
        ConfigurationManager anotherConfigManager = ConfigurationManager.Instance;

        // Checking if both instances are the same
        Console.WriteLine($"Is configManager the same as anotherConfigManager? {ReferenceEquals(configManager, anotherConfigManager)}");

        // Displaying the configuration settings
        Console.WriteLine($"Logging Mode: {anotherConfigManager.LoggingMode}");
        Console.WriteLine($"Database Connection: {anotherConfigManager.DatabaseConnection}");
    }
}
