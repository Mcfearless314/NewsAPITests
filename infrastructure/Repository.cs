using Dapper;
using infrastructure.DataModels;
using Npgsql;

namespace infrastructure;

public class Repository
{
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public Article CreateArticle(string headline, string body, string author, string articleImgUrl)
    {
        var sql =
            $@"INSERT INTO news.articles (headline, body, author, articleimgurl) VALUES(@headline, @body, @author, @articleImgUrl)
RETURNING 
    articleid AS {nameof(Article.ArticleId)},
    headline AS {nameof(Article.Headline)},
    body AS {nameof(Article.Body)},
    author AS {nameof(Article.Author)},
    articleimgurl AS {nameof(Article.ArticleImgUrl)};
";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new { headline, body, author, articleImgUrl });
        }
    }
}