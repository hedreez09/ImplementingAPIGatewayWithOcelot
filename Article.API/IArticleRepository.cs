namespace Article.API
{
    public interface IArticleRepository
    {
        List<Model.Article> GetAll();
        Model.Article? Get(int id);
        int Delete(int id);
    }
}
