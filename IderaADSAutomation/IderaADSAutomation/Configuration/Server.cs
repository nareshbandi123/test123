using System;

namespace IderaADSAutomation.Configuration
{
	public class Server
	{
		public Server()
		{
		}		
		
		public string ServerID {get; set;}
		public string ServerName {get; set;}
		public string ServerReady {get; set;}
		public string ManualPass {get; set;}
		public string LoginName{get; set;}
		public string LoginPassword{get; set;}
		public string HostName{get; set;}
		public string PortNumber{get; set;}
		public string DatabaseName{get; set;}
		public string AlternateDatabaseName{get; set;}
		public string NameXPath {get;set;}
		public string LoginNameXPath {get;set;}
		public string LoginPasswordXPath {get;set;}
		public string HostXPath {get;set;}
		public string PortXPath {get;set;}
		public string DBXPath {get;set;}
		public string RegistredServerName {get;set;}
		public string DatabaseKey {get;set;}
		public string VersionNo {get;set;}
		public string ServerNameActual {get;set;}
		public string TestScriptLocation {get;set;}
	}
}
