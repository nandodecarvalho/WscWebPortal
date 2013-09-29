using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// This class stores a series of common database access operations, to avoid typing it all over again in other places.It's functionality will be accessed from
/// the business tier. 
/// </summary>

public static class DataAccessClass
{
    // static constructor
    static DataAccessClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // executes a command and returns the results as a DataTable object
    public static DataTable ExecuteSelectCommand(DbCommand command)
    {
        
        DataTable table;
        try
        {
            
            command.Connection.Open();
            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            reader.Close();
        }
        catch (Exception ex)
        {
            Services.LogError(ex);
            throw;
        }
        finally
        {
            command.Connection.Close();
        }
        return table;
    }

    // New connection
    public static DbCommand CreateCommand()
    {
        
        string dataProviderName = WscWebPortalStaticData.DbProviderName;

        string connectionString = WscWebPortalStaticData.DbConnectionString;
        DbProviderFactory factory = DbProviderFactories.
        GetFactory(dataProviderName);
        DbConnection conn = factory.CreateConnection();
        conn.ConnectionString = connectionString;
        DbCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.StoredProcedure;
        return comm;
    }
}


