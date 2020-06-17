using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Microsoft.Edge.SeleniumTools;

namespace TestServerPlayground.Tests
{
	[TestFixture]
	public class Example6
	{
		[Test]
		public void Test1()
		{
			WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>();

			factory.CreateClient();

			EdgeOptions options = new EdgeOptions();
			options.UseChromium = true;

			EdgeDriver driver = new EdgeDriver(options);

			// Navigate to Bing
			driver.Url = "http://localhost.com/";

			// Find the search box and query for webdriver
			var element = driver.FindElementById("sb_form_q");

			element.SendKeys("webdriver");
			element.SendKeys(Keys.Enter);

			driver.Quit();
		}
	}
}
