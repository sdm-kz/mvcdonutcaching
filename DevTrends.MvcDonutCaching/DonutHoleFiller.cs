using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace DevTrends.MvcDonutCaching
{
    using System.Linq;
    using System.Text;

    public class DonutHoleFiller : IDonutHoleFiller
    {
        private static readonly Regex DonutHoles = new Regex("<!--Donut#(.*?)#-->(.*?)<!--EndDonut-->", RegexOptions.Compiled | RegexOptions.Singleline);

        private readonly IActionSettingsSerialiser _actionSettingsSerialiser;

        public DonutHoleFiller(IActionSettingsSerialiser actionSettingsSerialiser)
        {
            if (actionSettingsSerialiser == null)
            {
                throw new ArgumentNullException("actionSettingsSerialiser");
            }

            _actionSettingsSerialiser = actionSettingsSerialiser;
        }

        public string RemoveDonutHoleWrappers(string content, ControllerContext filterContext, OutputCacheOptions options)
        {
            if (
                filterContext.IsChildAction &&
                (options & OutputCacheOptions.ReplaceDonutsInChildActions) != OutputCacheOptions.ReplaceDonutsInChildActions)
            {
                return content;
            }

            return DonutHoles.Replace(content, match => match.Groups[2].Value);
        }

        public string ReplaceDonutHoleContent(string content, ControllerContext filterContext, OutputCacheOptions options)
        {
            if (filterContext.IsChildAction &&
                (options & OutputCacheOptions.ReplaceDonutsInChildActions) != OutputCacheOptions.ReplaceDonutsInChildActions)
            {
                return content;
            }

            var matches = FindDonutHoles(content);
            return ReplaceDonutMatches(matches, content, filterContext);
        }

        private DonutMatch[] FindDonutHoles(string content)
        {
            return DonutHoles
                .Matches(content)
                .Cast<Match>()
                .Select(
                    match => new DonutMatch
                    {
                        HoleMatch = match,
                        Settings = _actionSettingsSerialiser.Deserialise(match.Groups[1].Value),
                        TextIndex = match.Index
                    })
                .OrderBy(match => match.Settings.Order)
                .ToArray();
        }

        private string ReplaceDonutMatches(
            DonutMatch[] matches,
            string content,
            ControllerContext filterContext)
        {
            var newContent = new StringBuilder(content);
            for (var index = 0; index < matches.Length; index++)
            {
                var match = matches[index];
                var actionResult = InvokeAction(
                    filterContext.Controller,
                    match.Settings.ActionName,
                    match.Settings.ControllerName,
                    match.Settings.RouteValues);

                var shift = actionResult.Length - match.HoleMatch.Length;
                for (var nextIndex = index + 1; nextIndex < matches.Length; nextIndex++)
                {
                    var nextMatch = matches[nextIndex];
                    if (nextMatch.TextIndex > match.TextIndex)
                        nextMatch.TextIndex += shift;
                }

                newContent.Remove(match.TextIndex, match.HoleMatch.Length);
                newContent.Insert(match.TextIndex, actionResult);
            }

            return newContent.ToString();
        }

        private static string InvokeAction(ControllerBase controller, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            var viewContext = new ViewContext(
                controller.ControllerContext,
                new WebFormView(controller.ControllerContext, "tmp"),
                controller.ViewData,
                controller.TempData,
                TextWriter.Null
            );

            var htmlHelper = new HtmlHelper(viewContext, new ViewPage());

            return htmlHelper.Action(actionName, controllerName, routeValues).ToString();
        }
    }
}