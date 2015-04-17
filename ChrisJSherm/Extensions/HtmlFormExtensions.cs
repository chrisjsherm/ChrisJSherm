using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ChrisJSherm.Extensions
{
    public static class HtmlFormExtensions
    {
        public static MvcHtmlString FoundationValidationMessageFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            // Check if an error exists, otherwise return empty.
            if (helper.ValidationMessageFor(expression) != null)
            {
                TagBuilder small = new TagBuilder("small");
                small.AddCssClass("error-message");

                small.InnerHtml = helper.ValidationMessageFor(expression).ToHtmlString();

                return MvcHtmlString.Create(small.ToString());
            }

            return MvcHtmlString.Create(String.Empty);
        }
    }
}
