using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CoreTraining.Models;
using Microsoft.Extensions.Configuration;

namespace CoreTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IConfiguration _configuration;

    public ActivityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            var activities = new List<Activity>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("HubDatabase")))
            {
                const string sql = "SELECT Id, UniqueReferenceCode, CreationTime, QuotingRentMinId, QuotingRentMaxId FROM Activity";

                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var activity = new Activity()
                    {
                        Id = new Guid(reader["Id"].ToString() ?? string.Empty),
                        CreationTime = DateTimeOffset.Parse(reader["CreationTime"].ToString() ?? string.Empty),
                        QuotingRentMinId = new Guid(reader["QuotingRentMinId"].ToString() ?? string.Empty),
                        QuotingRentMaxId = new Guid(reader["QuotingRentMaxId"].ToString() ?? string.Empty),
                    };

                    activities.Add(activity);
                }
            }

            return activities;
        }
    }
}
