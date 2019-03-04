using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;

namespace IderaADSAutomation.Configuration
{
	public class RegisterServerData
	{
		public RegisterServerData()
		{
		}
		
		public DataTable LoadExcelData(string path)
		{
			// read file data and load in ServerList Object
			string connectionString = "";
			if (path.Contains(".xls"))
            {   //For Excel 97-03
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
            }
			else if (path.Contains(".xlsx"))
            {    //For Excel 07 and greater
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
            }
            connectionString = String.Format(connectionString, path, "Yes");
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            //Fetch 1st Sheet Name
            conn.Open();
            DataTable dtSchema;
            dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if(dtSchema!= null && dtSchema.Rows.Count > 0)
            {
	            string ExcelSheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
	            conn.Close();
	            //Read all data of fetched Sheet to a Data Table
	            conn.Open();
	            cmd.CommandText = "SELECT * From [" + ExcelSheetName + "]";
	            dataAdapter.SelectCommand = cmd;
	            dataAdapter.Fill(dt);
	            conn.Close();
            }
            return dt;
		}	
		
		public List<Server> GetActiveServers(string path, bool isCheckActive = true)
		{
			DataTable dtServerList = LoadExcelData(path);
			List<Server> servers = new List<Server>();
	
			foreach (DataRow dr in dtServerList.Rows) 
			{
				Server server = new Server();
				server.ServerID = dr[0].ToString().Trim();
				server.ServerName = dr["Server Name"].ToString().Trim();
				server.ServerReady = dr["Server Status"].ToString();
				server.ManualPass = dr["Registration Status RDP"].ToString();
				server.LoginName = dr["Login Name"].ToString().Trim();
				server.LoginPassword = dr["Password"].ToString().Trim();
				server.HostName = dr["Host"].ToString().Trim();
				server.PortNumber = dr["Port"].ToString().Trim();
				server.DatabaseName = dr["DBName"].ToString().Trim();
				server.AlternateDatabaseName = dr["Alternate DB"].ToString();
				server.NameXPath = dr["xPathName"].ToString().Trim();
				server.LoginNameXPath = dr["xPathLoginName"].ToString().Trim();
				server.LoginPasswordXPath = dr["xPathPassword"].ToString().Trim();
				server.HostXPath = dr["xPathHost"].ToString().Trim();
				server.PortXPath = dr["xPathPort"].ToString().Trim();
				if(!string.IsNullOrEmpty(Convert.ToString(dr["xPathDBName"]))){
					server.DBXPath = dr["xPathDBName"].ToString().Trim();
				}
				server.RegistredServerName = dr["Database"].ToString().Trim();
				server.DatabaseKey = dr["DatabaseKey"].ToString().Trim();
				server.VersionNo = dr["Version"].ToString().Trim();
				server.ServerNameActual = dr["Name"].ToString().Trim();
				
				if(isCheckActive)
				{
					if(server.ServerReady.Contains("Up") && server.ManualPass.Contains("Pass"))
						servers.Add(server);
				}
				else
				{
					servers.Add(server);
				}
			}
			
			return servers;
		}
		
		public Server GetSingleServer(string path, string serverName, bool isCheckActive = true)
		{
			DataTable dtServerList = LoadExcelData(path);
			Server server = new Server();
	
			foreach (DataRow dr in dtServerList.Rows) 
			{
				if(dr["Database"].ToString() == serverName){
				
					server.ServerID = dr[0].ToString().Trim();
					server.ServerName = dr["Server Name"].ToString().Trim();
					server.ServerReady = dr["Server Status"].ToString();
					server.ManualPass = dr["Registration Status RDP"].ToString();
					server.LoginName = dr["Login Name"].ToString().Trim();
					server.LoginPassword = dr["Password"].ToString().Trim();
					server.HostName = dr["Host"].ToString().Trim();
					server.PortNumber = dr["Port"].ToString().Trim();
					server.DatabaseName = dr["DBName"].ToString().Trim();
					server.AlternateDatabaseName = dr["Alternate DB"].ToString();
					server.NameXPath = dr["xPathName"].ToString().Trim();
					server.LoginNameXPath = dr["xPathLoginName"].ToString().Trim();
					server.LoginPasswordXPath = dr["xPathPassword"].ToString().Trim();
					server.HostXPath = dr["xPathHost"].ToString().Trim();
					server.PortXPath = dr["xPathPort"].ToString().Trim();
					if(!string.IsNullOrEmpty(Convert.ToString(dr["xPathDBName"]))){
						server.DBXPath = dr["xPathDBName"].ToString().Trim();
					}
					server.RegistredServerName = dr["Database"].ToString().Trim();
					server.DatabaseKey = dr["DatabaseKey"].ToString().Trim();
					server.VersionNo = dr["Version"].ToString().Trim();
					server.ServerNameActual = dr["Name"].ToString().Trim();
				}
			}
			
			return server;
		}
	}
}
