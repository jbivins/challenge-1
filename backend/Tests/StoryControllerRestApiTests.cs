using CodingChallenge;
using CodingChallenge.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
  public class StoryControllerRestApiTests : IntegrationTest
  {
    [Test]
    public async Task TestGetStories()
    {
      HttpResponseMessage response = await httpClient.GetAsync("/api/story");
      string responseString = await response.Content.ReadAsStringAsync();
      IEnumerable<Story> stories = JsonConvert.DeserializeObject<IEnumerable<Story>>(responseString);

      Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
      Assert.AreEqual(20, stories.Count());
    }

    [Test]
    public async Task TestGetFiftyStories()
    {
      HttpResponseMessage response = await httpClient.GetAsync("/api/story?pageIndex=0&pageSize=50");
      string responseString = await response.Content.ReadAsStringAsync();
      IEnumerable<Story> stories = JsonConvert.DeserializeObject<IEnumerable<Story>>(responseString);

      Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
      Assert.AreEqual(50, stories.Count());
    }

    [Test]
    public async Task TestGetStory()
    {
      int id = 23829963;
      HttpResponseMessage response = await httpClient.GetAsync("/api/story/" + id);
      string responseString = await response.Content.ReadAsStringAsync();
      Story story = JsonConvert.DeserializeObject<Story>(responseString);

      Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
      Assert.AreEqual(id, story.Id);
    }

    [Test]
    public async Task TestGetStoryCount()
    {
      HttpResponseMessage response = await httpClient.GetAsync("/api/story/count");
      string responseString = await response.Content.ReadAsStringAsync();
      int count = JsonConvert.DeserializeObject<int>(responseString);

      Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
      Assert.AreEqual(500, count);
    }

    [Test]
    public async Task TestGetStorySearch()
    {
      HttpResponseMessage response = await httpClient.GetAsync("/api/story/search/google");
      string responseString = await response.Content.ReadAsStringAsync();
      IEnumerable<Story> stories = JsonConvert.DeserializeObject<IEnumerable<Story>>(responseString);

      Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
      Assert.Greater(stories.Count(), 0);
    }
  }
}
