﻿using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;



namespace Intex_2.Models
{
	public class Helpers
	{
		public static string GetPgConnectionString()
		{
			var appConfig = ConfigurationManager.AppSettings;

			string pg_conn = appConfig["PG_CONNECTION"];

			return pg_conn;
		}

		public static string GetSqlConnectionString()
		{
			var appConfig = ConfigurationManager.AppSettings;

			string sql_conn = appConfig["SQL_CONNECTION"];

			return sql_conn;
		}
	}
}