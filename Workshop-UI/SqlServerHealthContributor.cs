﻿using System;
using Workshop_UI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using Steeltoe.Management.Endpoint.Health;
using System.Data.Common;
using System.Data.SqlClient;

namespace Workshop_UI
{
    public class SqlServerHealthContributor : IHealthContributor
    {
        AttendeeContext _context;
        ILogger<SqlServerHealthContributor> _logger;
        public SqlServerHealthContributor(AttendeeContext dbContext, ILogger<SqlServerHealthContributor> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        public string Id { get; } = "msSql";

        public Health Health()
        {
            _logger.LogInformation("Checking MSSQL connection health!");

            Health result = new Health();
            result.Details.Add("database", "MSSQL");
            SqlConnection _connection = null;
            try
            {
                _connection = _context.Database.GetDbConnection() as SqlConnection;
                if (_connection != null)
                {
                    _connection.Open();
                    DbCommand cmd = new SqlCommand("SELECT 1;", _connection);
                    var qresult = cmd.ExecuteScalar();
                    result.Details.Add("result", qresult);
                    result.Details.Add("status", HealthStatus.UP.ToString());
                    result.Status = HealthStatus.UP;
                    _logger.LogInformation("MSSQL Server connection up!");
                }

            }
            catch (Exception e)
            {
                _logger.LogInformation("MSSQL Server connection down!");
                result.Details.Add("error", e.GetType().Name + ": " + e.Message);
                result.Details.Add("status", HealthStatus.DOWN.ToString());
                result.Status = HealthStatus.DOWN;
            }
            finally
            {
                if (_connection != null) _connection.Close();
            }

            return result;
        }
    }
}
// Lab11 End
