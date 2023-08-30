using infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using service;

namespace api.Controllers;

[ApiController]
public class NewsController : ControllerBase
{
    private readonly Service _service;

    public NewsController(Service service)
    {
        _service = service;
    }


    [HttpPost]
    [Route("/api/articles")]
    public Article PostBook([FromBody] Article article)
    {
        return _service.CreateArticle(article.Headline, article.Body, article.Author, article.ArticleImgUrl);
    }
}