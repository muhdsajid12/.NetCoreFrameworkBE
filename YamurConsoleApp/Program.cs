// See https://aka.ms/new-console-template for more information
using BusinessLayer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;

// Build a config object, using env vars and JSON providers.
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Get values from the config given their key and their target type.
var settings = config.GetRequiredSection("Settings").Get<Dictionary<string, string?>>();

// TODO - Get list of commands
Dictionary<double, int> commands = await CommandManagement.GetIntervalCommandList();

// Set the Time Interval order by the time duration.
// Send Message
foreach(var command in commands) 
{


}

// Set the time interval (in milliseconds)
int interval = 60000; // 60,000 milliseconds = 1 minute

// Create a timer that calls the specified method every 'interval' milliseconds
Timer timer = new Timer(state => { WriteSomething(); }, null, 0, interval);


// Test
void WriteSomething()
{
    Console.WriteLine("1 minute has passed");
}

