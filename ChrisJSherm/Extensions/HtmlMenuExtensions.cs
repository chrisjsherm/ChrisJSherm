using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ChrisJSherm.Extensions
{
    public static class HtmlMenuExtensions
    {
        /* Description: Helper to add "active" class to the selected menu item.        
         * Usage: In the Views folder Web.config, add the namespace to the 
         * namspaces section. On your page:
         * @Html.MenuItem("Products", "Index", "Products")
         */
        public static MvcHtmlString MenuItem(
                this HtmlHelper htmlHelper,
                string text,
                string action,
                string controller
            )
        {
            var li = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }
            li.InnerHtml = htmlHelper.ActionLink(text, action, controller).ToHtmlString();
            return MvcHtmlString.Create(li.ToString());
        }
    }
}
