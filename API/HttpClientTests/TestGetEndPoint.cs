using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaywrightDemo.API.HttpClientTests
{
    public class TestGetEndPoint
    {
        private string expectedStatusCode = "StatusCode: 200";
        private string getUrl = "https://petstore.swagger.io/v2/pet/9223372036854745978";
        protected HttpClient client;

        [SetUp]
        public void SetUp()
        {
            // Set up the HTTP client
            client = new HttpClient();
        }

        [Test]
        public void GetEndPointUsingUrl()
        {
            Task<HttpResponseMessage> responce = client.GetAsync(getUrl);
            HttpResponseMessage fullMsg = responce.Result;
            var msgText = fullMsg.ToString();

            Assert.IsTrue(msgText.Contains(expectedStatusCode), $"Expected '{expectedStatusCode}' could not be found.");
            Console.WriteLine(msgText);
        }

        [Test]
        public void GetEndPointUsingUri()
        {
            Uri uri = new Uri(getUrl);

            // Creeate request and execute it
            Task<HttpResponseMessage> responce = client.GetAsync(uri);
            HttpResponseMessage fullMsg = responce.Result;
            var msgText = fullMsg.ToString();

            Assert.IsTrue(msgText.Contains(expectedStatusCode), $"Expected '{expectedStatusCode}' could not be found.");
            Console.WriteLine(msgText);

            // Status code
            var statusCode = fullMsg.StatusCode;
            Assert.AreEqual(200, (int)statusCode, "200 status code could not be found.");

            // Responce data
            var responceContent = fullMsg.Content;
            Task<string> responceData = responceContent.ReadAsStringAsync();
            var data  = responceData.Result;

            Console.WriteLine();
            Console.WriteLine(data);
        }

        [Test]
        public void GetEndPointUsingInvalidUrl()
        {
            Task<HttpResponseMessage> responce = client.GetAsync(getUrl + "/invalid");
            HttpResponseMessage fullMsg = responce.Result;
            var statusCode = fullMsg.StatusCode;

            Assert.AreEqual(404, (int)statusCode, "404 status code for invalid URL could not be found.");

            // Responce data
            var responceContent = fullMsg.Content;
            Task<string> responceData = responceContent.ReadAsStringAsync();
            var data = responceData.Result;

            Console.WriteLine();
            Console.WriteLine(data);
        }

        [Test]
        public void GetAllEndPointInJsonFormat()
        {
            var requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");

            Task<HttpResponseMessage> responce = client.GetAsync(getUrl);
            HttpResponseMessage fullMsg = responce.Result;
            var msgText = fullMsg.ToString();

            Assert.IsTrue(msgText.Contains(expectedStatusCode), $"Expected '{expectedStatusCode}' could not be found.");
            Console.WriteLine(msgText);

            // Status code
            var statusCode = fullMsg.StatusCode;
            Assert.AreEqual(200, (int)statusCode, "200 status code could not be found.");

            // Responce data
            var responceContent = fullMsg.Content;
            Task<string> responceData = responceContent.ReadAsStringAsync();
            var data = responceData.Result;

            Console.WriteLine();
            Console.WriteLine(data);
        }

        [Test]
        public void GetAllEndPointInXmlFormat()
        {
            var requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> responce = client.GetAsync(getUrl);
            HttpResponseMessage fullMsg = responce.Result;
            var msgText = fullMsg.ToString();

            Assert.IsTrue(msgText.Contains(expectedStatusCode), $"Expected '{expectedStatusCode}' could not be found.");
            Console.WriteLine(msgText);

            // Status code
            var statusCode = fullMsg.StatusCode;
            Assert.AreEqual(200, (int)statusCode, "200 status code could not be found.");

            // Responce data
            var responceContent = fullMsg.Content;
            Task<string> responceData = responceContent.ReadAsStringAsync();
            var data = responceData.Result;

            Console.WriteLine();
            Console.WriteLine(data);
        }

        [Test]
        public void GetAllEndPointInJsonFormatUsingAcceptHeader()
        {
            var requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> responce = client.GetAsync(getUrl);
            HttpResponseMessage fullMsg = responce.Result;
            var msgText = fullMsg.ToString();

            Assert.IsTrue(msgText.Contains(expectedStatusCode), $"Expected '{expectedStatusCode}' could not be found.");
            Console.WriteLine(msgText);

            // Status code
            var statusCode = fullMsg.StatusCode;
            Assert.AreEqual(200, (int)statusCode, "200 status code could not be found.");

            // Responce data
            var responceContent = fullMsg.Content;
            Task<string> responceData = responceContent.ReadAsStringAsync();
            var data = responceData.Result;

            Console.WriteLine();
            Console.WriteLine(data);
        }

        [Test]
        public void GetEndPointUsingSendAsync()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.RequestUri = new Uri(getUrl);
            httpRequest.Method = HttpMethod.Get;
            httpRequest.Headers.Add("Accept", "application/json");

            Task<HttpResponseMessage> responce = client.SendAsync(httpRequest);
            HttpResponseMessage fullMsg = responce.Result;
            var msgText = fullMsg.ToString();

            Assert.IsTrue(msgText.Contains(expectedStatusCode), $"Expected '{expectedStatusCode}' could not be found.");
            Console.WriteLine(msgText);

            // Status code
            var statusCode = fullMsg.StatusCode;
            Assert.AreEqual(200, (int)statusCode, "200 status code could not be found.");

            // Responce data
            var responceContent = fullMsg.Content;
            Task<string> responceData = responceContent.ReadAsStringAsync();
            var data = responceData.Result;

            Console.WriteLine();
            Console.WriteLine(data);
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
