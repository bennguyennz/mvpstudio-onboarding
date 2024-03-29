﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Onboarding.Utilities
{
    [Binding]
    class ExtentReport
    {
        static AventStack.ExtentReports.ExtentReports extent;

        [ThreadStatic]
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, step;

        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "TestReport"
            + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + Path.DirectorySeparatorChar;

        //static ExtentKlovReporter klovreport;
        //public static ConfigSetting config;
        //static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName
        //    + Path.DirectorySeparatorChar + "Configuration/configsetting.json";



        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //config = new ConfigSetting();
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddJsonFile(configsettingpath);
            //IConfigurationRoot configuration = builder.Build();
            //configuration.Bind(config);


            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();

            //klovreport = new ExtentKlovReporter();
            //klovreport.InitMongoDbConnection("localhost", 27017);
            //klovreport.ProjectName = "MyProject";
            extent.AttachReporter(htmlreport);//,klovreport);


            //LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Information);
            //Log.Logger = new LoggerConfiguration()
            //            .MinimumLevel.ControlledBy(levelSwitch)
            //            .WriteTo.File(new JsonFormatter(), reportpath + @"\Logs").CreateLogger();
            //outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}",
            //rollingInterval: RollingInterval.Day).CreateLogger();

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
            //Log.Information("Selecting feature file {0} to run", context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeSceanrio(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            //Log.Information("Selecting scenario {0} to run", context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                //Log.Error("Test Step Failed | " + context.TestError.Message);
                string base64 = GetScreenshot();
                step.Log(Status.Fail, context.StepContext.StepInfo.Text, 
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                CommonDriver.driver.Quit();
            }
        }


        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        //Pass the driver: CommonDriver.driver
        public string GetScreenshot()
        {
            return ((ITakesScreenshot)CommonDriver.driver).GetScreenshot().AsBase64EncodedString;
        }

    }
}
