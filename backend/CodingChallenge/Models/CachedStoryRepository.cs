using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Models
{
  public class CachedStoryRepository : StoryRepository
  {
    private readonly IMemoryCache cache;
    const string STORIES_CACHE_KEY = "stories";
    const string STORY_IDS_CACHE_KEY = "story_ids";
    const string STORY_CACHE_KEY = "story";

    public CachedStoryRepository(IMemoryCache cache)
    {
      this.cache = cache;
    }

    public override IEnumerable<Story> GetLatestStories()
    {
      if (!cache.TryGetValue(STORIES_CACHE_KEY, out IEnumerable<Story> stories))
      {
        stories = base.GetLatestStories();
        cache.Set(STORIES_CACHE_KEY, stories, new MemoryCacheEntryOptions
        {
          AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
        });
      }

      return stories;
    }

    public override IEnumerable<int> GetLatestStoryIds()
    {
      if (!cache.TryGetValue(STORY_IDS_CACHE_KEY, out IEnumerable<int> storyIds))
      {
        storyIds = base.GetLatestStoryIds();
        cache.Set(STORY_IDS_CACHE_KEY, storyIds, new MemoryCacheEntryOptions
        {
          AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
        });
      }

      return storyIds;
    }

    public override Story GetStory(int id)
    {
      if (!cache.TryGetValue(STORY_CACHE_KEY + id, out Story story))
      {
        story = base.GetStory(id);
        cache.Set(STORIES_CACHE_KEY + id, story, new MemoryCacheEntryOptions
        {
          AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
        });
      }

      return story;
    }
  }
}
