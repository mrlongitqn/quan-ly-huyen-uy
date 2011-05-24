using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// tuansl added: used for searching by criterias
    /// </summary>
    public class Criteria
    {
        // Data provider object
        public string DBName { get; set; }
        public DBProvider DBProvider { get; set; }

        /// <summary>
        /// Init database which contains list of tables that are used for searching by criterias
        /// </summary>
        /// <param name="DB"></param>
        public Table InitCriterias()
        {
            // Create new connect to DB
            CreateConnection(GlobalVars.g_strTenMayTram, GlobalVars.g_strDataBaseName);

            var ds = new DataSet();
            DBProvider.SqlQuery = "Select * From " + DBName + " ";
            DBProvider.FillDataSet(ref ds, DBName);

            Table tbl = new Table();
            InitTable(ds.Tables[DBName], ref tbl);

            // Set foreign keys
            SetForeignKey(tbl);

            return tbl;
        }

        /// <summary>
        /// Set foreign keys for tables in DB
        /// </summary>
        /// <param name="DB"></param>
        private void SetForeignKey(Table table)
        {
            Microsoft.SqlServer.Management.Smo.Database db;
            Microsoft.SqlServer.Management.Smo.Server server;

            //build a "serverConnection" with the information of the "sqlConnection"
            Microsoft.SqlServer.Management.Common.ServerConnection serverConnection =
              new Microsoft.SqlServer.Management.Common.ServerConnection(DBProvider.ObjConnection);

            //The "serverConnection is used in the ctor of the Server.
            server = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);

            db = server.Databases[DBProvider.DataBaseName];

            Microsoft.SqlServer.Management.Smo.Table tbl;
            //get foreign key list of corresponding table
            tbl = db.Tables[table.Name];

            for (int j = 0; j < table.Attributes.Count; j++)
            {
                string referTo = "";
                if (IsExistOn(ConvertSOMTable2List(tbl), table.Attributes[j].Name, ref referTo))
                {
                    table.Attributes[j].IsForeignKey = true;
                    table.Attributes[j].ReferTo = referTo;
                }
            }
            var lstPK = GetListPK(tbl);
            for (int j = 0; j < table.Attributes.Count; j++)
            {
                for (int k = 0; k < lstPK.Count; k++)
                {
                    if (lstPK[k].Name == table.Attributes[j].Name)
                    {
                        table.Attributes[j].IsPrimaryKey = true;
                        table.Attributes[j].IsIdentify = lstPK[k].IsIdentify;
                    }
                }
            }
        }

        /// <summary>
        /// Get list foreign keys of a table
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        private List<PrimaryKey> GetListPK(Microsoft.SqlServer.Management.Smo.Table tbl)
        {
            var lst = new List<PrimaryKey>();
            var columns = tbl.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].InPrimaryKey)
                {
                    if (columns[i].Identity)
                        lst.Add(new PrimaryKey { Name = columns[i].Name, IsIdentify = true });
                    else
                        lst.Add(new PrimaryKey { Name = columns[i].Name, IsIdentify = false });
                }
            }
            return lst;
        }

        /// <summary>
        /// Convert SOM table to list
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        private List<ForeignKey> ConvertSOMTable2List(Microsoft.SqlServer.Management.Smo.Table tbl)
        {
            List<ForeignKey> lstItem = new List<ForeignKey>();

            foreach (Microsoft.SqlServer.Management.Smo.ForeignKey fk in tbl.ForeignKeys)
            {
                var Item = new ForeignKey
                {
                    Name = GetFKs(fk),
                    ReferTo = fk.ReferencedTable
                };
                lstItem.Add(Item);
            }

            return lstItem;
        }

        /// <summary>
        /// Get list of foreign ley 
        /// </summary>
        /// <param name="fk"></param>
        /// <returns></returns>
        private List<string> GetFKs(Microsoft.SqlServer.Management.Smo.ForeignKey fk)
        {
            List<string> lstFK = new List<string>();
            foreach (Microsoft.SqlServer.Management.Smo.ForeignKeyColumn key in fk.Columns)
            {
                lstFK.Add(key.Name);
            }
            return lstFK;
        }

        /// <summary>
        /// Checking if item is exist in list
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="item"></param>
        /// <param name="referto"></param>
        /// <returns></returns>
        private bool IsExistOn(List<ForeignKey> lst, string item, ref string referto)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                foreach (string key in lst[i].Name)
                {
                    if (key == item)
                    {
                        referto = lst[i].ReferTo;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Init component of a table
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="tbl"></param>
        private void InitTable(DataTable dataTable, ref Table tbl)
        {
            tbl.Name = dataTable.TableName;
            DataColumn[] columns = dataTable.PrimaryKey;

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var col = dataTable.Columns[i];
                var Attr = new Attribute
                {
                    Name = col.ColumnName,
                    Type = GetType(col.DataType)
                };
                tbl.Attributes.Add(Attr);
            }
            tbl.Attributes.Sort((x, y) => string.Compare(x.Name, y.Name));
        }

        /// <summary>
        /// From obtained data type, convert it to enum DataType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private DataType GetType(Type type)
        {
            switch (type.ToString())
            {
                case "System.String":
                    return DataType.STRING;

                case "System.Float":
                    return DataType.FLOAT;

                case "System.Double":
                    return DataType.DOUBLE;

                case "System.Int32":
                    return DataType.INT;

                case "System.Int64":
                    return DataType.LONG;

                case "System.Guid":
                    return DataType.GUILD;

                case "System.Boolean":
                    return DataType.BOOL;

                case "System.DateTime":
                    return DataType.DATETIME;

                default:
                    return DataType.STRING;
            }
        }

        /// <summary>
        /// Create Connection
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dataBase"></param>
        private void CreateConnection(string dataSource, string dataBase)
        {
            DBProvider.InitDBProvider(dataSource, dataBase);
        }
    }
}
