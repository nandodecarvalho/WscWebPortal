using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for StoreSearchClass
/// </summary>
public class StoreSearchClass
{
	public StoreSearchClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    // This method is used for searching for a particular product
    public static DataTable SearchStore(string searchQuery, string allQueries, string pageNumber, out int howManyPages)
    {
        
        DbCommand comm = DataAccessClass.CreateCommand();        
        comm.CommandText = "SearchAdvanced";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = WscWebPortalStaticData.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@AllQueries";
        //to make sure word case doesn't matter 
        param.Value = allQueries.ToUpper() == "TRUE" ? "1" : "0";
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = WscWebPortalStaticData.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyResults";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        int howManyWords = 3;
        // transform search string into array of words
        string[] words = Regex.Split(searchQuery, "[^a-zA-Z0-9]+");

        
        int index = 1;
        for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
            if (words[i].Length > 2)
            {
               
                param = comm.CreateParameter();
                param.ParameterName = "@Query" + index.ToString();

                param.Value = words[i];
                param.DbType = DbType.String;
                comm.Parameters.Add(param);
                index++;
            }

        
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        int howManyProducts =
        Int32.Parse(comm.Parameters["@HowManyResults"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /(double)WscWebPortalStaticData.ProductsPerPage);
         return table;
    }

    
}