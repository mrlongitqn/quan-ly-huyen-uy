using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// tuansl added: data provider class
    /// </summary>
    public class DBProvider
    {
        /// <summary>
        /// cac bien thanh phan thuc hien thao tac truy xuat CSDL
        /// </summary>
        public String SqlQuery { get; set; }//bien giu vai tro la cau lenh truy van
        public SqlConnection ObjConnection { get; set; }
        public SqlCommand ObjCommand { get; set; }
        public SqlDataAdapter ObjDataAdapter { get; set; }
        public SqlDataReader ObjDataReader { get; set; }
        public string DataSource { get; set; }
        public string DataBaseName { get; set; }
        /// <summary>
        /// truyen duong dan toi thuc muc chua database de thuc thi ket noi
        /// </summary>
        /// <param name="strPath"></param>
        public void InitDBProvider(string dataSource, string databaseName)
        {
            try
            {
                DataSource = dataSource;
                DataBaseName = databaseName;
                ObjConnection = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog=" + databaseName + ";Integrated Security=True");
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        /// <summary>
        /// Add parameter cho cau lenh truy van
        /// </summary>
        /// <param name="Name"></param> 
        /// <param name="Type"></param>
        /// <param name="Size"></param>
        /// <param name="Value"></param>
        public void AddParameter(string Name, SqlDbType Type, int Size, object Value)
        {
            try
            {
                ObjCommand.Parameters.Add(Name, Type, Size).Value = Value;

            }
            catch (System.Exception SqlExceptionErr)
            {
                throw new System.Exception(SqlExceptionErr.Message,
                SqlExceptionErr.InnerException);
            }
        }
        /// <summary>
        /// mo ket noi
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                ObjConnection.Open();
            }
            catch (SqlException SqlExceptionErr)
            {
                throw new Exception(SqlExceptionErr.Message, SqlExceptionErr.InnerException);
            }
            catch (InvalidOperationException InvalidOperationExceptionErr)
            {
                throw new Exception(InvalidOperationExceptionErr.Message, InvalidOperationExceptionErr.InnerException);
            }
        }
        /// <summary>
        /// dong ket noi
        /// </summary>
        public void CloseConnection()
        {
            ObjConnection.Close();
        }
        /// <summary>
        /// Khoi tao cau lenh truy van
        /// </summary>
        public void InitializeCommand()
        {
            if (ObjCommand == null)
            {
                try
                {
                    ObjCommand = new SqlCommand(SqlQuery, ObjConnection);
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message, e.InnerException);
                }
            }
        }
        public void InitializeDataAdapter()
        {
            try
            {
                ObjDataAdapter = new SqlDataAdapter();
                ObjDataAdapter.SelectCommand = ObjCommand;//lua chon cau lenh
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        /// <summary>
        /// do du lieu vao dataset
        /// </summary>
        /// <param name="daoDataSet"></param>
        /// <param name="TableName"></param>
        public void FillDataSet(ref DataSet daoDataSet, String TableName)
        {
            try
            {
                InitializeCommand();
                InitializeDataAdapter();
                ObjDataAdapter.Fill(daoDataSet, TableName);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                ObjCommand.Dispose();
                ObjCommand = null;
                ObjDataAdapter.Dispose();
                ObjDataAdapter = null;
            }
        }
        /// <summary>
        /// do du lieu vao dataTable
        /// </summary>
        /// <param name="daoDataSet"></param>
        /// <param name="TableName"></param>
        public void FillDataTable(ref DataTable oDataTable)
        {
            try
            {
                InitializeCommand();
                InitializeDataAdapter();
                ObjDataAdapter.Fill(oDataTable);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                ObjCommand.Dispose();
                ObjCommand = null;
                ObjDataAdapter.Dispose();
                ObjDataAdapter = null;
            }
        }
        /// <summary>
        /// thuc thi cau truy van
        /// </summary>
        /// <returns>thuc thi xong, dong ket noi tra ve 1 bao thanh cong</returns>
        public Boolean ExecuteStoredProcedure()
        {
            try
            {
                OpenConnection();
                if (ObjCommand.ExecuteNonQuery() != 0)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;//that bai
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
    }
}
