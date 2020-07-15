using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodingChallenge.Models
{
  public class StoryRepository : IStoryRepository
  {
    const string BASE_ENDPOINT_URL = "https://hacker-news.firebaseio.com/v0/";

    public virtual IEnumerable<Story> GetLatestStories()
    {
      IEnumerable<int> storyIds = GetLatestStoryIds();
      List<Story> stories = new List<Story>();

      foreach (int storyId in storyIds)
      {
        stories.Add(GetStory(storyId));
      }

      return stories;
    }

    public virtual IEnumerable<Story> GetLatestStories(int startIndex, int size)
    {
      IEnumerable<int> storyIds = GetLatestStoryIds().Skip(startIndex).Take(size);
      ConcurrentQueue<Story> stories = new ConcurrentQueue<Story>();

      var tasks = storyIds.Select(storyId => Task.Factory.StartNew(
        state =>
        {
          stories.Enqueue(GetStory(storyId));
        }, storyId
      )).ToArray();

      Task.WaitAll(tasks);

      return stories;
    }

    public virtual IEnumerable<int> GetLatestStoryIds()
    {
      WebClient client = new WebClient();
      string response;

      response = client.DownloadString(BASE_ENDPOINT_URL + "newstories.json");

      return JsonConvert.DeserializeObject<List<int>>(response);
    }

    public virtual Story GetStory(int id)
    {
      WebClient client = new WebClient();
      string response;
      string filename = "cache/item_" + id + ".json";

      if (File.Exists(filename))
      {
        response = File.ReadAllText(filename);
      }
      else
      {
        response = client.DownloadString(BASE_ENDPOINT_URL + "item/" + id + ".json");
        File.WriteAllText(filename, response);
      }

      return JsonConvert.DeserializeObject<Story>(response);
    }
  }
}
