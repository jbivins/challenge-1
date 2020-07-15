using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoryController : ControllerBase
  {
    private readonly IStoryRepository repository;
    public const int DEFAULT_PAGESIZE = 20;

    public StoryController(IStoryRepository repository)
    {
      this.repository = repository;
    }

    // GET: api/<StoryController>
    [HttpGet]
    public IEnumerable<Story> Get(int pageIndex, int pageSize)
    {
      pageSize = (pageSize > 0) ? pageSize : DEFAULT_PAGESIZE;

      return repository.GetLatestStories(pageIndex * pageSize, pageSize);
    }

    // GET: api/<StoryController>/count
    [HttpGet("count")]
    public int GetCount()
    {
      return repository.GetLatestStoryIds().Count();
    }

    // GET api/<StoryController>/5
    [HttpGet("{id}")]
    public Story Get(int id)
    {
      return repository.GetStory(id);
    }

    // GET: api/<StoryController>/search/google
    [HttpGet("search/{phrase}")]
    public IEnumerable<Story> GetSearch(string phrase)
    {
      return repository.GetLatestStories().Where(x => x != null && x.Title.Contains(phrase, StringComparison.InvariantCultureIgnoreCase)).Take(DEFAULT_PAGESIZE);
    }
  }
}
