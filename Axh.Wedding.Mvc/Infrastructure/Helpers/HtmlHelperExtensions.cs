namespace Axh.Wedding.Mvc.Infrastructure.Helpers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.Mvc;

    using Axh.Wedding.Resources;
    using Axh.Wedding.Application.ViewModels.Page;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString WriteModelJson(this HtmlHelper helper)
        {
            var model = helper.ViewData.Model;
            var type = model.GetType();
            var jsonProperties =
                type.GetProperties()
                    .Select(prop => new { Attribute = prop.GetCustomAttribute<BindClientPropertyAttribute>(true), Property = prop })
                    .Where(x => x.Attribute != null)
                    .Select(x => new JProperty(x.Attribute.Name ?? x.Property.Name, x.Property.GetValue(model) ?? "undefined"));

            var json = new JObject(jsonProperties);

            var tagBuilder = new TagBuilder("script") { InnerHtml = string.Format("var model = {0};", json.ToString(Formatting.None)) };

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString FormatAddress<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, string>> addressExpr, Expression<Func<TModel, string>> phoneExpr = null)
        {
            var model = helper.ViewData.Model;
            var address = addressExpr.Compile()(model);

            var addressHtml = string.Join(
                new TagBuilder("br").ToString(TagRenderMode.SelfClosing),
                address.Split(',').Select((line, i) => i == 0 ? new TagBuilder("strong") { InnerHtml = line.Trim() }.ToString() : line.Trim()));

            if (phoneExpr != null)
            {
                var phone = phoneExpr.Compile()(model);
                var phoneIcon = new TagBuilder("i");
                phoneIcon.MergeAttribute("class", "fa fa-phone fa-fw");
                var abbrTag = new TagBuilder("abbr") { InnerHtml = phoneIcon.ToString() };
                abbrTag.MergeAttribute("title", Resources.TelephoneNumber);
                addressHtml += string.Format("{0}{1} {2}", new TagBuilder("br").ToString(TagRenderMode.SelfClosing), abbrTag.ToString(), phone);
            }

            var addressTag = new TagBuilder("address") { InnerHtml = addressHtml };
            return new MvcHtmlString(addressTag.ToString());
        }

    }
}