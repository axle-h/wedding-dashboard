﻿namespace Axh.Wedding.Mvc.Infrastructure.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.Mvc;

    using Axh.Wedding.Resources;
    using Axh.Wedding.Application.ViewModels.Page;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class HtmlHelperExtensions
    {
        private static readonly IContractResolver ContractResolver = new BindClientPropertyContractResolver();

        public static MvcHtmlString WriteModelJson(this HtmlHelper helper)
        {
            var model = helper.ViewData.Model;

            var serializerSettings = new JsonSerializerSettings { ContractResolver = ContractResolver, Formatting = Formatting.None };
            var json = JsonConvert.SerializeObject(model, serializerSettings);
            var tagBuilder = new TagBuilder("script") { InnerHtml = string.Format("var model = {0};", json) };

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

        public static MvcHtmlString GetDisplayValue<TModel, TEnum>(this HtmlHelper<TModel> helper, TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return new MvcHtmlString(attribute == null ? value.ToString() : attribute.Description);
        }

        public static MvcHtmlString GetDisplayValue<TModel, TEnum>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TEnum>> enumExpr)
        {
            var model = helper.ViewData.Model;
            var value = enumExpr.Compile()(model);
            
            return GetDisplayValue(helper, value);
        }

        private static string GetDescription<TEnum>(this TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        private class BindClientPropertyContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);

                var bindAttribute = member.GetCustomAttribute<BindClientPropertyAttribute>(true);

                if (bindAttribute == null)
                {
                    property.ShouldSerialize = instance => false;
                }
                else if (!string.IsNullOrEmpty(bindAttribute.Name))
                {
                    property.PropertyName = bindAttribute.Name;
                }

                property.NullValueHandling = NullValueHandling.Ignore;

                return property;
            }
        }

    }
}