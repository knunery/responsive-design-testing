using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace responsive_design_testing
{
    public static class ScreenshotHelper
    {
        public static FileInfo GetFileInfo([CallerMemberName] string callerName = "")
        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "..\\..\\..\\screenshots\\" + callerName + ".png";
            string fullPath = directory + filename;
            Console.WriteLine(fullPath);

            FileInfo fileInfo = new FileInfo(fullPath);

            return fileInfo;
        }
    }

    [TestFixture]
    public class ScreenshotTests
    {
        [TestFixtureSetUp]
        public void TakeScreenshots()
        {
            

            string baseUrl = "http://twitter.github.com/bootstrap/";
            List<string> urls = new List<string>{"index", "getting-started", "scaffolding"};
            List<int> screenSizes = new List<int>{480, 767, 980};

            urls.ForEach(url =>
                {
                    screenSizes.ForEach(screenSize =>
                        {
                            var fullUrl = string.Format("{0}{1}.html", baseUrl, url);
                            var fileName = string.Format("./../../screenshots/{0}_width_{1}.png", url, screenSize);

                            var args = "screenshot.js" + " " + fullUrl + " " + fileName + " " + screenSize;
                            Console.WriteLine(args);

                            var startInfo = new ProcessStartInfo();
                            startInfo.Arguments = args;
                            startInfo.FileName = "..\\..\\phantomjs.exe";
                            //startInfo.WorkingDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\"));

                            startInfo.UseShellExecute = false;
                            startInfo.RedirectStandardError = true;
                            startInfo.RedirectStandardOutput = true;
                            startInfo.CreateNoWindow = true;
                            
                            var proc = Process.Start(startInfo);

                            proc.WaitForExit();

                            var errorMessage = proc.StandardError.ReadToEnd();
                            var outputMessage = proc.StandardOutput.ReadToEnd();

                            Console.WriteLine(outputMessage);

                            
                        });

                });

        }

        [Test]
        public void RunSetup()
        {
        }

        [Test, UseReporter(typeof(ImageReporter))]
        public void index_width_480()
        {
            Approvals.Verify(ScreenshotHelper.GetFileInfo());
        }

        [Test, UseReporter(typeof(ImageReporter))]
        public void index_width_767()
        {
            Approvals.Verify(ScreenshotHelper.GetFileInfo());
        }

        [Test, UseReporter(typeof(ImageReporter))]
        public void index_width_980()
        {
            Approvals.Verify(ScreenshotHelper.GetFileInfo());
        }

        [Test, UseReporter(typeof(ImageReporter))]
        public void scaffolding_width_480()
        {
            Approvals.Verify(ScreenshotHelper.GetFileInfo());
        }

        [Test, UseReporter(typeof(ImageReporter))]
        public void scaffolding_width_767()
        {
            Approvals.Verify(ScreenshotHelper.GetFileInfo());
        }

        [Test, UseReporter(typeof(ImageReporter))]
        public void scaffolding_width_980()
        {
            Approvals.Verify(ScreenshotHelper.GetFileInfo());
        }
    }
}
