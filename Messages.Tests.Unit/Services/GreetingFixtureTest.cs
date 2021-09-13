using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace Messages.Tests.Unit.Services
{
    public class GreetingFixtureTest : IDisposable
    {
        public ExtentReports extent;
        public ExtentTest extentTest;

        public GreetingFixtureTest()
        {
            var report = new ExtentHtmlReporter("index.html");
            extent = new ExtentReports();
            extent.AttachReporter(report);
            extentTest = extent.CreateTest("Message Service").CreateNode("Greeting");
            extentTest.AssignAuthor("Programemos.net");
        }

        public void Dispose()
        {
            extent.Flush();
        }
    }
}
