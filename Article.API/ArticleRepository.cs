using Intercom.Core;
using System.Reflection;

using Article.API.Model;

namespace Article.API
{
    public class ArticleRepository : List<Model.Article>, IArticleRepository
    {
        private readonly static List<Model.Article> _article = Populate();

        private static List<Model.Article> Populate()
        {
            var result = new List<Model.Article>()
            {
            new Model.Article
            {
                Id = 1,
                Title = "First Article",
                WriterId = 1,
                LastUpdate = DateTime.Now
            },
            new Model.Article
            {
                Id = 2,
                Title = "Second title",
                WriterId = 2,
                LastUpdate = DateTime.Now
            },
            new Model.Article
            {
                Id = 3,
                Title = "Third title",
                WriterId = 3,
                LastUpdate = DateTime.Now
            }
        };

            return result;
        }

        public List<Model.Article> GetAll()
        {
            return _article;
        }

        public Model.Article? Get(int id)
        {
            return _article.FirstOrDefault(x => x.Id == id);
        }

        public int Delete(int id)
        {
            var removed = _article.SingleOrDefault(x => x.Id == id);
            if (removed != null)
                _article.Remove(removed);

            return removed?.Id ?? 0;
        }
    }
}
