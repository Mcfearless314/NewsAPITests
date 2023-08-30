using infrastructure;
using infrastructure.DataModels;

namespace service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }

    public Article CreateArticle(string headline, string body, string author, string articleImgUrl)
    {
        try
        {
            return _repository.CreateArticle(headline, body, author, articleImgUrl);
        }
        catch (Exception)
        {
            throw new Exception("Could not create article");
        }
    }
}