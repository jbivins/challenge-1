using CodingChallenge.Models;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
  public class StoryRepositoryTests
  {
    private IStoryRepository storyRepository;

    [SetUp]
    public void Setup()
    {
      storyRepository = new StoryRepository();
    }

    [Test]
    public void TestGetLatestStoryIds()
    {
      int storyId = storyRepository.GetLatestStoryIds().FirstOrDefault();

      Assert.Greater(storyId, 0);
    }

    [Test]
    public void TestGetLatestStories()
    {
      Story story = storyRepository.GetLatestStories().FirstOrDefault();

      Assert.Greater(story.Id, 0);
    }

    [Test]
    public void TestGetStory()
    {
      int id = 23829963;
      Story story = storyRepository.GetStory(id);

      Assert.AreEqual(id, story.Id);
    }
  }
}