using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using RepositeryLayer.Shared;

namespace CommanClsLibrary
{
    /// <summary>
    /// This Class used to communicate with Database
    /// </summary>
    public class MyClass
    {

        private readonly IConfiguration _configuration;
        //public MyClass(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        #region "Global Declaration"
        private SqlConnection Cnn = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        private SqlDataAdapter Da = new SqlDataAdapter();
        public DataSet Ds = new DataSet();
        #endregion


        public MyClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Userd To Open a connection 
        /// </summary>
        /// <returns> Boolean </returns>
        public Boolean OpenCnn()
        {
            try
            {
                if (Cnn.ConnectionString != "")
                {
                    Cnn.Dispose();
                }
                string a = clssetting.strCoonectionString;

                Cnn.ConnectionString = a;
                return true;
            }
            catch (Exception ex)
            {
               // MyClass.SendErrorMail(ex.ToString());
                ex.ToString();
                return false;

            }
        }

        /// <summary>
        /// Userd To Close the connection 
        /// </summary>
        /// <returns></returns>
        public Boolean CloseCnn()
        {
            try
            {

                Cmd.Dispose();
                Ds.Dispose();
                Da.Dispose();
                Cnn.Dispose();
                return true;
            }
            catch (Exception Err)
            {
                Err.ToString();
                return false;
            }
        }


        /// <summary>
        /// Used to Execute Commands (Insert,Update and Delete ) with SqlCommand Object
        /// </summary>
        /// <param name="Query in String "></param>
        /// <param name="SqlCommand Object "></param>
        public void ExecuteCommand(string Sql, SqlCommand cmdn)
        {
            cmdn.CommandType = CommandType.Text;
            cmdn.CommandText = Sql;
            cmdn.ExecuteNonQuery();

        }


        /// <summary>
        /// Used to Execute Commands (Insert,Update and Delete )
        /// </summary>
        /// <param name="Query in String"></param>
        /// <returns> Return '' in case of success</returns>
        public String ExecuteCommand(string Sql)
        {

            try
            {
                if (Cnn.ConnectionString != "") Cnn.Dispose();
                OpenCnn();
                Cmd.CommandText = "";
                Cmd = new SqlCommand(Sql, Cnn);
                Cmd.Connection.Open();
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                return "";
            }
            catch (Exception ex)
            {
                //MyClass.SendErrorMail(ex.ToString());
                Cmd.Dispose();
                CloseCnn();
                return ex.ToString();
            }
        }



        /// <summary>
        /// Used to get Data Set from Query 
        /// </summary>
        /// <param name="Query in String"></param>
        /// <returns></returns>
        public Boolean OpenReturenDs(string Sql)
        {
            try
            {
                if (Cnn.ConnectionString != "") Cnn.Dispose();
                OpenCnn();
                Da.Dispose();
                Ds = null;
                Ds = new DataSet();
                Da = new SqlDataAdapter(Sql, Cnn);
                Da.Fill(Ds);
                if (Cnn.ConnectionString != "") Cnn.Dispose();
                Da.Dispose();
                return true;
            }
            catch (Exception Err)
            {
                if (Cnn.ConnectionString != "") Cnn.Dispose();
                Da.Dispose();
                Err.ToString();
                return false;
            }
        }



        //***********************************************************************************
        /// <summary>
        /// Use to get single value from Sql Query String 
        /// </summary>
        /// <param name="Query in String"></param>
        /// <returns>string Value </returns>
        public string GetExecuteScalar(string strQuery)
        {
            string strret = "";

            using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
            {
                try
                {
                    SqlCommand cmd =
                        new SqlCommand(strQuery, connection);
                    connection.Open();
                    object strret1 = cmd.ExecuteScalar();
                    if (strret1 != null)
                    {
                        if (strret1.ToString().Length > 0)
                            strret = strret1.ToString();
                    }

                }
                catch
                {
                    // MyClass.SendErrorMail(ex.ToString() + "    " + strQuery);
                }
                finally
                {
                    if (connection != null) { connection.Close(); }

                }
            }




            return strret;
        }


        /// <summary>
        /// Use to get single value from Sql Query String with SqlCommand 
        /// </summary>
        /// <param name="Query in String"></param>
        /// <param name="SqlCommand cmd"></param>
        /// <returns>string Value</returns>
        public string GetExecuteScalar(string strQuery, SqlCommand cmd)
        {
            string strret = "";

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            object strret1 = cmd.ExecuteScalar();
            if (strret1 != null)
            {
                if (strret1.ToString().Length > 0)
                    strret = strret1.ToString();
            }
            return strret;
        }

        //*************************************************************************************

        /// <summary>
        /// Use to get single value from Sql Procedure 
        /// </summary>
        /// <param name="Procedure Name "></param>
        /// <param name="List of Paramenters "></param>
        /// <returns>string Value</returns>
        public String GetSingleValueByProcedure(string Procedure, List<String> value)
        {
            String strret = "";
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = Procedure;
                    connection.Open();
                    List<StoreProcedureParamList> parm = ListParms(Procedure);
                    int x = 0;
                    foreach (StoreProcedureParamList p in parm)
                    {
                        if (value[x].ToString().Trim().Length > 0)
                            command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = value[x].ToString();
                        else
                            command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = System.Data.SqlTypes.SqlString.Null;
                        x++;
                    }



                    object strret1 = command.ExecuteScalar();
                    if (strret1 != null)
                    {
                        if (strret1.ToString().Length > 0)
                            strret = strret1.ToString();
                    }
                    return strret;
                }
            }
            catch
            {
                return strret;
            }

        }




        //*********************************************************************************
        /// <summary>
        /// Use to get Parameters of Procedure in Datatable 
        /// </summary>
        /// <param name="Procedure"></param>
        /// <returns>DataTable</returns>
        public DataTable GetProcedure(string Procedure)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = Procedure;
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                //MyClass.SendErrorMail(ex.ToString());
                return dt;
            }

        }

        /// <summary>
        /// Store Procedure Param List
        /// </summary>
        public class StoreProcedureParamList
        {
            private string _ParmName = "";
            public string ParmName
            {
                get { return _ParmName; }
                set { _ParmName = value; }
            }
            private DbType _ParmDbType;
            public DbType ParmDbType
            {
                get { return _ParmDbType; }
                set { _ParmDbType = value; }
            }

        }

        /// <summary>
        /// Store Procedure Parameter List
        /// </summary>
        /// <param name="procname"></param>
        /// <returns> List of Procedure Parameter  </returns>
        private List<StoreProcedureParamList> ListParms(string procname)
        {
            List<StoreProcedureParamList> parm = new List<StoreProcedureParamList>();
            using (SqlConnection conn = new SqlConnection(clssetting.strCoonectionString))
            {
                SqlCommand cmd = new SqlCommand(procname, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlCommandBuilder.DeriveParameters(cmd);


                foreach (SqlParameter p in cmd.Parameters)
                {
                    if (p.ParameterName.ToUpper() != "@RETURN_VALUE")
                    {
                        StoreProcedureParamList obj = new StoreProcedureParamList();
                        obj.ParmName = p.ParameterName;
                        obj.ParmDbType = p.DbType;
                        parm.Add(obj);
                    }
                }
                conn.Close();
                cmd.Dispose();
            }

            return parm;

        }



        /// <summary>
        /// Get DataTable By Procedure with Parameters
        /// </summary>
        /// <param name="Name of Procedure"></param>
        /// <param name="List of Procedure Parameter"></param>
        /// <returns>DataTable</returns>
        public DataTable GetDtByProcedure(string Procedure, List<String> value)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = Procedure;
                    connection.Open();
                    List<StoreProcedureParamList> parm = ListParms(Procedure);
                    int x = 0;
                    foreach (StoreProcedureParamList p in parm)
                    {
                        if (value[x].ToString().Trim().Length > 0)
                            command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = value[x].ToString();
                        else
                            command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = System.Data.SqlTypes.SqlString.Null;
                        x++;
                    }




                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    if (connection != null) { connection.Close(); }
                    command.Dispose();
                    value.Clear();
                    return dt;
                }
            }
            catch(Exception ex)
            {
                // MyClass.SendErrorMail(ex.ToString() + "   " + Procedure);
                return dt;
            }

        }


        /// <summary>
        /// Get DataSet By Procedure with Parameters
        /// </summary>
        /// <param name="Name of Procedure"></param>
        /// <param name="List of Procedure Parameter"></param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSetByProcedure(string Procedure, List<String> value)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = Procedure;
                    connection.Open();
                    List<StoreProcedureParamList> parm = ListParms(Procedure);
                    int x = 0;
                    foreach (StoreProcedureParamList p in parm)
                    {
                        if (value[x].ToString().Trim().Length > 0)
                            command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = value[x].ToString();
                        else
                            command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = System.Data.SqlTypes.SqlString.Null;
                        x++;
                    }




                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    connection.Close();
                    command.Dispose();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                // MyClass.SendErrorMail(ex.ToString() + "   " + Procedure);
                return dt;
            }

        }


        /// <summary>
        /// Use to Get Data Set
        /// </summary>
        /// <param name="SQL Query"></param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string Query)
        {
            DataSet dt = new DataSet();
            try
            {
                if (Cnn.ConnectionString != "") Cnn.Dispose();
                OpenCnn();
                Da.Dispose();
                Ds = null;
                Ds = new DataSet();
                Da = new SqlDataAdapter(Query, Cnn);
                Da.Fill(Ds);
                dt = Ds;
                return dt;

            }
            catch
            {
                // MyClass.SendErrorMail(ex.ToString() + "   " + Procedure);
                return dt;
            }

        }


        /// <summary>
        /// Execute (Insert/Update/Delete) By Procedure with List of Procedure Parameter
        /// </summary>
        /// <param name="Procedure Name "></param>
        /// <param name="List of Procedure Parameter"></param>
        /// <returns>bool</returns>
        public bool ExecuteByProcedure(string Procedure, List<String> value)
        {
            bool ret = false;
            using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Procedure;
                connection.Open();
                List<StoreProcedureParamList> parm = ListParms(Procedure);
                int x = 0;
                foreach (StoreProcedureParamList p in parm)
                {
                    if (value[x].ToString().Trim().Length > 0)
                        command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = value[x].ToString();
                    else
                        command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = System.Data.SqlTypes.SqlString.Null;
                    x++;
                }
                int d = command.ExecuteNonQuery();
                if (d != 0)
                {
                    ret = true;
                }
                connection.Close();
                command.Dispose();


            }
            return ret;
        }


        /// <summary>
        /// Execute (Insert/Update/Delete) By Procedure with List of Procedure Parameter
        /// </summary>
        /// <param name="Procedure Name "></param>
        /// <param name="List of Procedure Parameter"></param>
        /// <param name=" SqlCommand command object "></param>
        public void ExecuteByProcedure(string Procedure, List<String> value, SqlCommand command)
        {

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Procedure;

            List<StoreProcedureParamList> parm = ListParms(Procedure);
            int x = 0;
            foreach (StoreProcedureParamList p in parm)
            {
                if (value[x].ToString().Trim().Length > 0)
                    command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = value[x].ToString();
                else
                    command.Parameters.AddWithValue(p.ParmName, p.ParmDbType).Value = System.Data.SqlTypes.SqlString.Null;
                x++;
            }
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            value.Clear();
        }








        #region "User for Date Format conversion"
        public string mdy(string strdt)
        {
            if (strdt.Trim().Length > 0)
            {
                string[] dt; string ndt;
                if (strdt.Contains("/"))
                {
                    dt = strdt.Trim().Split('/');
                    ndt = dt[1] + "/" + dt[0] + "/" + dt[2];

                }
                else
                {
                    dt = strdt.Trim().Split('-');
                    ndt = dt[1] + "/" + dt[0] + "/" + dt[2];
                }

                string stt = ndt;
                return stt;
            }
            else
            {
                return "";
            }
        }

        public string dmy(string strdt)
        {
            if (strdt == "") return null;
            DateTime d;
            string[] dt; string ndt;
            if (strdt.Contains("/"))
            {
                dt = strdt.Trim().Split('/');
                ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }
            else
            {
                dt = strdt.Trim().Split('-');
                ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }
            try
            {
                d = DateTime.Parse(ndt);
            }
            catch
            {
                ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
                d = DateTime.Parse(ndt);
            }
            string stt = d.ToString("dd/MM/yyyy");
            return stt;
        }

        public string ymd(string strdt)
        {
            if (strdt == "") return null;
            string[] dt; string ndt;
            if (strdt.Contains("/"))
            {
                dt = strdt.Trim().Split('/');
                // ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }
            else
            {
                dt = strdt.Trim().Split('-');
                //ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }

            ndt = dt[2] + "/" + dt[1] + "/" + dt[0];

            return ndt.Trim();
        }

        public string ymd2(string strdt)
        {
            if (strdt == "") return null;
            string[] dt; string ndt;
            if (strdt.Contains("/"))
            {
                dt = strdt.Trim().Split('/');
                // ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }
            else
            {
                dt = strdt.Trim().Split('-');
                //ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }

            ndt = dt[2] + "-" + dt[1] + "-" + dt[0];

            return ndt.Trim();
        }

        public string dmy_2(string strdt)
        {

            if (strdt == "") return null;
            string[] dt; string ndt;
            if (strdt.Contains("/"))
            {
                dt = strdt.Trim().Split('/');
                // ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }
            else
            {
                dt = strdt.Trim().Split('-');
                //ndt = dt[0] + "/" + dt[1] + "/" + dt[2];
            }

            ndt =  dt[0] + "/" + dt[1] + "/" + dt[2];

            return ndt.Trim();
        }
        #endregion


        /// <summary>
        /// This will use to genrate PK in case of SQL Transaction . 
        /// </summary>
        /// <param name="Table Name"></param>
        /// <param name="Primary Key Name"></param>
        /// <param name="SqlCommand Object"></param>
        /// <returns>Primary Key</returns>
        public int TableID(string TableName, string FieldName, SqlCommand cmd)
        {

            int TableID;
            DataTable dt = GetDataTable("SELECT  MAX(" + FieldName + ") AS ID FROM  " + TableName + " HAVING  MAX(" + FieldName + ") IS NOT NULL", cmd);
            if (dt.Rows.Count != 0)
            {
                TableID = Convert.ToInt32(dt.Rows[0]["ID"].ToString()) + 1;
            }
            else
                TableID = 1;
            return TableID;
        }

        /// <summary>
        /// This will use to genrate PK. 
        /// </summary>
        /// <param name="Table Name"></param>
        /// <param name="Primary Key Name"></param>
        /// <returns>Primary Key</returns>
        public int TableID(string TableName, string FieldName)
        {
            MyClass scnn = new MyClass();
            int TableID;
            scnn.OpenCnn();
            String str = scnn.GetExecuteScalar("SELECT  MAX(" + FieldName + ") AS ID FROM  " + TableName + " HAVING  MAX(" + FieldName + ") IS NOT NULL");
            if (str.Length > 0)
            {
                TableID = Convert.ToInt32(str) + 1;
            }
            else
                TableID = 1;
            return TableID;
        }

        /// <summary>
        /// Use to get DataTable from SQL Query 
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string strQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    SqlCommand command =
                        new SqlCommand(strQuery, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                // MyClass.SendErrorMail(ex.ToString() + "  " + strQuery);

            }
            return dt;
        }


        /// <summary>
        /// Use to get DataTable from SQL Query in case of SQL Transaction . 
        /// </summary>
        /// <param name="string SQL Query"></param>
        /// <param name="SqlCommand cmd"></param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string strQuery, SqlCommand cmd)
        {
            DataTable dt = new DataTable();


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;

        }


        /// <summary>
        /// Get Server Date in DD/MM/YYYY
        /// </summary>
        /// <returns>String Date</returns>
        public string SvrDate()
        {
            string Svrdt;
            Svrdt = GetExecuteScalar("SELECT   CONVERT(VARCHAR(20) ,GETDATE(),103) AS dt");
            return Svrdt;

        }

        /// <summary>
        /// Get Unique Number from Database
        /// </summary>
        /// <param name="Degits (Length of Number) "></param>
        /// <returns>string Number</returns>
        public string GetSqlUnikNO(String Degits)
        {
            string Svrdt;
            Svrdt = GetExecuteScalar("select CONVERT(varchar(10), right(newid()," + Degits + "))");
            return Svrdt.Trim();
        }


        /// <summary>
        /// TO Check validation using Regular Expression 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public bool checkExprationValidation(String value, string regex)
        {
            bool ret = true;
            var match = Regex.Match(value, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                // does not match
                ret = false;
            }
            return ret;

        }

        /// <summary>
        ///Put String in Quotes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string PutIntoQuotes(string value)
        {
            return "\"" + value + "\"";
        }



        /// <summary>
        /// Use to Execute Multiple SQL Query Within Sql Transaction
        /// </summary>
        /// <param name="list of SQL Query"></param>
        /// <returns></returns>
        public String ExecuteMultiQueryWithCommand(List<String> lst)
        {
            String ret = "";

            MyClass cla = new MyClass();
            using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("CTransaction");
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {


                    foreach (String str in lst)
                    {
                        cla.ExecuteCommand(str, command);
                    }





                    transaction.Commit();
                    ret = "";


                }
                catch (Exception ex)
                {
                    //String error = "Error in Add Journey Save button Click " + ex.ToString();
                    //WriteError(error, Session["UserEmailID"].ToString());
                    try
                    {
                        transaction.Rollback();

                    }
                    catch
                    {

                    }
                    ret = ex.Message.Trim();
                }
                finally
                {
                    connection.Close();
                    command.Dispose();
                }

            }

            return ret;
        }
        
        
        #region change data from row to column
        public DataTable FlipDataTable(DataTable dt)
        {
            DataTable table = new DataTable();
            //Get all the rows and change into columns
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow dr;
            //get all the columns and make it as rows
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dr = table.NewRow();
                dr[0] = dt.Columns[j].ToString();
                for (int k = 1; k <= dt.Rows.Count; k++)
                    dr[k] = dt.Rows[k - 1][j];
                table.Rows.Add(dr);
            }

            return table;
        }
        #endregion

        /*
       * Added at 28-07-2019
       *  To get a common Control bind
       */

        /// <summary>
        ///bind the  gridview by passing gidview name and datatable data
        /// </summary>
        /// <param name="grdView"></param>
        /// <param name="dtabBindGridView"></param>
        //public static void BindGridView(GridView grdView, DataTable dtabBindGridView)
        //{
        //    try
        //    {
        //        if (dtabBindGridView.Rows.Count == 0)
        //        {
        //            grdView.AllowPaging = false;
        //            grdView.DataSource = null;
        //            grdView.DataBind();
        //            return;
        //        }
        //        else
        //        {
        //            grdView.DataSource = dtabBindGridView;
        //            grdView.DataBind();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        ///  To bind the checkbox list dyanmic
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataValueField"></param>
        /// <param name="dataTextField"></param>
        /// <param name="dtab"></param>

        //public static void BindCheckBoxList(CheckBoxList ddl, string dataValueField, string dataTextField, DataTable dtab)
        //{
        //    try
        //    {
        //        if (dtab.Rows.Count == 0)
        //        {
        //            ddl.Items.Clear();
        //            // ddl.Items.Insert(0, new ListItem("<-Select->", "NULL"));
        //            return;
        //        }
        //        else
        //        {

        //            ddl.DataSource = dtab;
        //            ddl.DataTextField = dataTextField;
        //            ddl.DataValueField = dataValueField;
        //            ddl.DataBind();
        //            // ddl.Items.Insert(0, new ListItem("<-Select->", "NULL"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        /// <summary>
        /// Bind the dropdownlist dynamically
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataValueField"></param>
        /// <param name="dataTextField"></param>
        /// <param name="dtab"></param>
        //public static void BindDropDownList(DropDownList ddl, string dataValueField, string dataTextField, DataTable dtab, string topitem)
        //{
        //    try
        //    {
        //        if (dtab.Rows.Count == 0)
        //        {
        //            ddl.Items.Clear();
        //            ddl.Items.Insert(0, new ListItem(topitem, "0"));
        //            return;
        //        }
        //        else
        //        {

        //            ddl.DataSource = dtab;
        //            ddl.DataTextField = dataTextField;
        //            ddl.DataValueField = dataValueField;
        //            ddl.DataBind();
        //            ddl.Items.Insert(0, new ListItem(topitem, "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        /// <summary>
        ///  Bind the ComboBox without assigned textfield and valuefield of combobox 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="List"></param>
        /// <param name="topitem"></param>
        //public static void BindDropDownList(DropDownList ddl, List<string> dtab, string topitem)
        //{
        //    try
        //    {
        //        if (dtab.Count == 0)
        //        {
        //            ddl.Items.Clear();
        //            ddl.Items.Insert(0, new ListItem(topitem, "0"));
        //            return;
        //        }
        //        else
        //        {
        //            ddl.DataSource = dtab;
        //            ddl.DataBind();
        //            ddl.Items.Insert(0, new ListItem(topitem, "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        /// <summary>
        /// BindCheckBoxList
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataValueField"></param>
        /// <param name="dataTextField"></param>
        /// <param name="dtab"></param>
        //public static void BindCheckBox1(CheckBoxList chk, string dataValueField, string dataTextField, DataTable dtab)
        //{
        //    try
        //    {
        //        if (dtab.Rows.Count == 0)
        //        {
        //            chk.Items.Clear();
        //            chk.Items.Insert(0, new ListItem("<-Select->", "0"));
        //            return;
        //        }
        //        else
        //        {
        //            foreach (DataRow dr in dtab.Rows)
        //            {
        //                ListItem item = new ListItem();
        //                item.Text = dr[dataTextField].ToString();
        //                item.Value = dr[dataValueField].ToString();
        //                //item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
        //                chk.Items.Add(item);
        //            }
        //            //chk.DataSource = dtab;
        //            //chk.DataTextField = dataTextField;
        //            //chk.DataValueField = dataValueField;
        //            //chk.DataBind();
        //            //chk.Items.Insert(0, new ListItem("<-Select->", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static void BindListBox(ListBox ddl, string dataValueField, string dataTextField, DataTable dtab)
        //{
        //    try
        //    {
        //        if (dtab.Rows.Count > 0)
        //        {
        //            ddl.DataSource = dtab;
        //            ddl.DataTextField = dataTextField;
        //            ddl.DataValueField = dataValueField;
        //            ddl.DataBind();
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable GetDataAstabl_Para(SqlCommand cmd)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    // command.CommandText = Procedure;
                    connection.Open();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    connection.Close();
                    cmd.Dispose();
                    return dt;

                }
            }
            catch (Exception ex)
            {
                return dt;
            }
            
        }


        public String GetExecuteScalar_Para(SqlCommand cmd)
        {

            String retval = String.Empty;
           
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    // command.CommandText = Procedure;
                    connection.Open();
                    //sda.SelectCommand = cmd;
                    //sda.Fill(dt);
                    retval = Convert.ToString(cmd.ExecuteScalar());
                    connection.Close();
                    cmd.Dispose();
                    return retval;

                }
            }
            catch (Exception ex)
            {
                return retval;
            }

        }


        public Boolean InserUpdateDel_Para(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clssetting.strCoonectionString))
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    // command.CommandText = Procedure;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    cmd.Dispose();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// This method is written for deselecting the Checked List Item
        /// </summary>
        /// <param name="ddl"></param>
        //public static void ListItemDeselect(ListBox ddl)
        //{
        //    foreach (ListItem list in ddl.Items)
        //    {
        //        list.Selected = false;
        //    }
        //}
    }
}
