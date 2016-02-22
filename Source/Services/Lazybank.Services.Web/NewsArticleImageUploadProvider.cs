using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lazybank.Services.Web
{
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
