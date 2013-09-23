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
        // The DataTable to be returned
        DataTable table;
        // Execute the command, making sure the connection gets closed in the
        // end
        try
        {
            // Open the data connection
            command.Connection.Open();
            // Execute the command and save the results in a DataTable
            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            // Close the reader
            reader.Close();
        }
        catch (Exception ex)
        {
            Services.LogError(ex);
            throw;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        return table;
    }

    // creates and prepares a new DbCommand object on a new connection
    public static DbCommand CreateCommand()
    {
        // Obtain the database provider name
        string dataProviderName = WscWebPortalConfiguration.DbProviderName;

        // Obtain the database connection string
        string connectionString = WscWebPortalConfiguration.DbConnectionString;
        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.
        GetFactory(dataProviderName);
        // Obtain a database-specific connection object
        DbConnection conn = factory.CreateConnection();
        // Set the connection string
        conn.ConnectionString = connectionString;
        // Create a database-specific command object
        DbCommand comm = conn.CreateCommand();
        // Set the command type to stored procedure
        comm.CommandType = CommandType.StoredProcedure;
        // Return the initialized command object
        return comm;
    }
}

