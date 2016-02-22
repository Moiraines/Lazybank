namespace Lazybank.Web.Areas.Public
{
    using System.Web.Mvc;

    public class PublicAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Public";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Public_default",
                "Public/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}