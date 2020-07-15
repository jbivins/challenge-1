using CodingChallenge;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace Tests
{
  public class IntegrationTest
  {
    protected readonly HttpClient httpClient;

    public IntegrationTest() {
      var webAppFactory = new WebApplicationFactory<Startup>();
      httpClient = webAppFactory.CreateClient();
    }
  }
}
