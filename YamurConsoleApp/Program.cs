// See https://aka.ms/new-console-template for more information
using BusinessLayer;

Console.WriteLine("Hello, World!");

// Set the time interval (in milliseconds)
int interval = 60000; // 60,000 milliseconds = 1 minute

// Create a timer that calls the specified method every 'interval' milliseconds
Timer timer = new Timer(async state => await CommandManagement.GetAutoCommandList(), null, 0, interval);

Console.WriteLine("Press Enter to stop the application.");
Console.ReadLine();
