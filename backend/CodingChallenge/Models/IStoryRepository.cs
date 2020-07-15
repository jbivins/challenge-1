using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingChallenge.Models
{
  public interface IStoryRepository
  {
    IEnumerable<int> GetLatestStoryIds();
    IEnumerable<Story> GetLatestStories();
    IEnumerable<Story> GetLatestStories(int startIndex, int size);
    Story GetStory(int id);
  }
}
