using CodingChallenge.Controllers;
using CodingChallenge.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
  public class StoryControllerTests
  {
    private StoryController storyController;

    [SetUp]
    public void Setup()
    {
      storyController = new StoryController(new StoryRepository());
    }

    [Test]
    public void TestGetWithSpecificPagesize()
    {
      int pageSize = 10;
      IEnumerable<Story> stories = storyController.Get(0, pageSize);

      Assert.AreEqual(pageSize, stories.Count());
    }

    [Test]
    public void TestGetWithDefaultPagesize()
    {
      IEnumerable<Story> stories = storyController.Get(0, 0);

      Assert.AreEqual(StoryController.DEFAULT_PAGESIZE, stories.Count());
    }

    [Test]
    public void TestGetStoryCount()
    {
      int count = storyController.GetCount();

      Assert.AreEqual(500, count);
    }
  }
}
