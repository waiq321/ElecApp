using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for DBManager
/// </summary>
public class DBManager
{
    SqlDataAdapter _SqlAdapter = new SqlDataAdapter();
    SqlConnection _SqlCon;
    SqlCommand _SqlCommand = new SqlCommand();
    DataTable _dataTable = new DataTable();
    DataSet _dataSet = new DataSet();
    public void Openconn(string connStr)
    {
        try
        {
            string constr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;
            _SqlCon = new SqlConnection(constr);
            _SqlCon.Open();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable ExecuteDataTable(string ProcedureName, string connStr, SqlParameter[] prms)
    {
        try
        {
            Openconn(connStr);
            _SqlCommand = new SqlCommand(ProcedureName, _SqlCon);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = ProcedureName;
            foreach (SqlParameter sqlParam in prms)
            {
                _SqlCommand.Parameters.Add(sqlParam);
            }

            _SqlAdapter.SelectCommand = _SqlCommand;
            _SqlAdapter.Fill(_dataTable);
            _SqlCon.Close();
            _SqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return _dataTable;
    }

    public DataTable ExecuteDataTableWithQuery(string query, string connStr, SqlParameter[] prms)
    {
        try
        {
            Openconn(connStr);
            _SqlCommand = new SqlCommand(query, _SqlCon);
            _SqlCommand.CommandType = CommandType.Text;
            foreach (SqlParameter sqlParam in prms)
            {
                _SqlCommand.Parameters.Add(sqlParam);
            }

            _SqlAdapter.SelectCommand = _SqlCommand;
            _SqlAdapter.Fill(_dataTable);
            _SqlCon.Close();
            _SqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return _dataTable;
    }

    public DataSet ExecuteDataSet(string ProcedureName, string connStr, SqlParameter[] prms)
    {
        try
        {
            Openconn(connStr);
            _SqlCommand = new SqlCommand(ProcedureName, _SqlCon);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = ProcedureName;
            foreach (SqlParameter sqlParam in prms)
            {
                _SqlCommand.Parameters.Add(sqlParam);
            }

            _SqlAdapter.SelectCommand = _SqlCommand;
            _SqlAdapter.Fill(_dataSet);
            _SqlCon.Close();
            _SqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return _dataSet;
    }

    public void ExecuteNonQuery(string ProcedureName, string connStr, SqlParameter[] prms)
    {
        try
        {
            Openconn(connStr);
            _SqlCommand = new SqlCommand(ProcedureName, _SqlCon);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = ProcedureName;
            foreach (SqlParameter sqlParam in prms)
            {
                _SqlCommand.Parameters.Add(sqlParam);
            }

            _SqlCommand.ExecuteNonQuery();
            _SqlCon.Close();
            _SqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable ExecuteDataTable_Query(string query, string connStr, SqlParameter[] prms)
    {
        try
        {
            Openconn(connStr);
            _SqlCommand = new SqlCommand(query, _SqlCon);
            foreach (SqlParameter sqlParam in prms)
            {
                _SqlCommand.Parameters.Add(sqlParam);
            }

            _SqlAdapter.SelectCommand = _SqlCommand;
            _SqlAdapter.Fill(_dataTable);
            _SqlCon.Close();
            _SqlCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return _dataTable;
    }
}