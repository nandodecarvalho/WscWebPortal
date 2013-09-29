using System.Configuration;

/// <summary>
/// This file configures WscWebPortal settings: Email,Database connection, portal name and etc.
/// It is a collection of static properties that return data from web.config instead of reading them on every reques Yeahh! Performance!
/// </summary>
public static class WscWebPortalStaticData
{
    
    private static string dbConnectionString;
    private static string dbProviderName;
    private readonly static int productsPerPage;
    private readonly static int productDescriptionLength;
    private readonly static string PortalName;

    static WscWebPortalStaticData()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["WscWebPortalConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["WscWebPortalConnection"].ProviderName;
        productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
        productDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings
        ["ProductDescriptionLength"]); PortalName = ConfigurationManager.AppSettings["PortalName"];
    }

    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    public static string DbProviderName
    {
        get
        {
            return dbProviderName;

        }
    }

     public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    public static string MailUsername
    {
        get
        {
            return ConfigurationManager.AppSettings["MailUsername"];
        }
    }

    public static string MailPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["MailPassword"];
        }
    }

     public static string MailFrom
    {
        get
        {
            return ConfigurationManager.AppSettings["MailFrom"];
        }
    }

    public static bool EnableErrorLogEmail
    {

        get
        {
            return bool.Parse(ConfigurationManager.AppSettings
            ["EnableErrorLogEmail"]);
        }
    }

    public static string ErrorLogEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ErrorLogEmail"];
        }
    }

    public static int ProductsPerPage
    {
        get
        {
            return productsPerPage;
        }
    }

    public static int ProductDescriptionLength
    {
        get
        {
            return productDescriptionLength;
        }
    }

   public static string SiteName
    {
        get
        {
            return PortalName;
        }
    }
}