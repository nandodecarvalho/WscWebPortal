using System.Configuration;

/// <summary>
/// This file configures WscWebPortal settings: Email,Database connection, portal name and etc.
/// It is a collection of static properties that return data from web.config instead of reading them on every reques Yeahh! Performance!
/// </summary>
public static class WscWebPortalConfiguration
{
    // Caches the connection string
    private static string dbConnectionString;
    // Caches the data provider name
    private static string dbProviderName;
    //Store the number of products per page
    private readonly static int productsPerPage;
    // Product description length for product lists
    private readonly static int productDescriptionLength;
    // Name of the Portal
    private readonly static string PortalName;

    static WscWebPortalConfiguration()
      {
        dbConnectionString = ConfigurationManager.ConnectionStrings    ["WscWebPortalConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["WscWebPortalConnection"].ProviderName;
        productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
        productDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings
        ["ProductDescriptionLength"]); PortalName = ConfigurationManager.AppSettings["PortalName"];
      }

    // Returns the connection string for the WscWebPortal database
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    // Returns the data provider name
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;

        }
    }

    // Returns the address of the mail server
    public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    // Returns the email username
    public static string MailUsername
    {
        get
        {
            return ConfigurationManager.AppSettings["MailUsername"];
        }
    }

    // Returns the email password
    public static string MailPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["MailPassword"];
        }
    }

    // Returns the email password
    public static string MailFrom
    {
        get
        {
            return ConfigurationManager.AppSettings["MailFrom"];
        }
    }

    // Send error log emails?
    public static bool EnableErrorLogEmail
    {

        get
        {
            return bool.Parse(ConfigurationManager.AppSettings
            ["EnableErrorLogEmail"]);
        }
    }

    // Returns the email address where to send error reports
    public static string ErrorLogEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ErrorLogEmail"];
        }
    }

    // Maximum number of products to be displayed on a page
    public static int ProductsPerPage
    {
        get
        {
            return productsPerPage;
        }
    }

    // The length of product descriptions in products lists
    public static int ProductDescriptionLength
    {
        get
        {
            return productDescriptionLength;
        }
    }

    // Returns the Portal name
    public static string SiteName
    {
        get
        {
            return PortalName;
        }
    }
}