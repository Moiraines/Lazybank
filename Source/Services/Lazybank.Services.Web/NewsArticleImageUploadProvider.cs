namespace Lazybank.Services.Web
{
    using System.Web;

    public class NewsArticleImageUploadProvider
    {
        public string Save(HttpServerUtilityBase server, HttpPostedFileBase file)
        {
            string path = "/img/" + file.FileName;
            string fullPath = server.MapPath(path);
            file.SaveAs(fullPath);

            return path;
        }
    }
}
