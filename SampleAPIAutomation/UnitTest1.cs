using System;
using System.Net;
using API_Automation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace SampleAPIAutomation
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void TestMethod2()
        {
            CommonMethods.SetBaseUri();
            IRestResponse response= CommonMethods.GetResponseOfResource("api/users?page=2");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
            Console.WriteLine(response.Content);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string path = AppContext.BaseDirectory;
            path = path + "\\TestData\\post.json";
            CommonMethods.SetBaseUri();           
            IRestResponse response = CommonMethods.PostResponseOfResource("api/register", path);
            Console.WriteLine(response.Content);
        }
    }
}
