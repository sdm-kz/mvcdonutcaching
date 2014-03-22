using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using DevTrends.MvcDonutCaching.Annotations;

namespace DevTrends.MvcDonutCaching
{
    public static class HtmlHelperExtensions
    {
        private static IActionSettingsSerialiser _serialiser;

        public static IActionSettingsSerialiser Serialiser
        {
            get
            {
                return _serialiser ??  (_serialiser = new EncryptingActionSettingsSerialiser(new ActionSettingsSerialiser(), new Encryptor()));
            }
            set
            {
                _serialiser = value;
            }
        }

        /// <summary>
        /// Invokes the specified child action method and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, bool excludeFromParentCache, int order = 0)
        {
            return htmlHelper.Action(actionName, null, null, excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, object routeValues, bool excludeFromParentCache, int order = 0)
        {
            return htmlHelper.Action(actionName, null, new RouteValueDictionary(routeValues), excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, RouteValueDictionary routeValues, bool excludeFromParentCache, int order = 0)
        {
            return htmlHelper.Action(actionName, null, routeValues, excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, bool excludeFromParentCache, int order = 0)
        {
            return htmlHelper.Action(actionName, controllerName, null, excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, object routeValues, bool excludeFromParentCache, int order = 0)
        {
            return htmlHelper.Action(actionName, controllerName, new RouteValueDictionary(routeValues), excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>

        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, bool excludeFromParentCache, int order = 0)
        {
            RenderAction(htmlHelper, actionName, null, null, excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, object routeValues, bool excludeFromParentCache, int order = 0)
        {
            RenderAction(htmlHelper, actionName, null, new RouteValueDictionary(routeValues), excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>        
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, RouteValueDictionary routeValues, bool excludeFromParentCache, int order = 0)
        {
            RenderAction(htmlHelper, actionName, null, routeValues, excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>        
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, bool excludeFromParentCache, int order = 0)
        {
            RenderAction(htmlHelper, actionName, controllerName, null, excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, object routeValues, bool excludeFromParentCache, int order = 0)
        {
            RenderAction(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues), excludeFromParentCache, order);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, RouteValueDictionary routeValues, bool excludeFromParentCache, int order = 0)
        {
            if (excludeFromParentCache)
            {
                var serialisedActionSettings = GetSerialisedActionSettings(actionName, controllerName, routeValues, order);

                htmlHelper.ViewContext.Writer.Write("<!--Donut#{0}#-->", serialisedActionSettings);
            }

            htmlHelper.RenderAction(actionName, controllerName, routeValues);

            if (excludeFromParentCache)
            {
                htmlHelper.ViewContext.Writer.Write("<!--EndDonut-->");
            }
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <param name="order">The ordinal index of action according to it will be invoked.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, RouteValueDictionary routeValues, bool excludeFromParentCache, int order = 0)
        {
            if (excludeFromParentCache)
            {
                var serialisedActionSettings = GetSerialisedActionSettings(actionName, controllerName, routeValues, order);

                return new MvcHtmlString(string.Format("<!--Donut#{0}#-->{1}<!--EndDonut-->", serialisedActionSettings, htmlHelper.Action(actionName, controllerName, routeValues)));
            }

            return htmlHelper.Action(actionName, controllerName, routeValues);
        }

        private static string GetSerialisedActionSettings(string actionName, string controllerName, RouteValueDictionary routeValues, int order = 0)
        {
            var actionSettings = new ActionSettings
            {
                ActionName = actionName,
                ControllerName = controllerName,
                RouteValues = routeValues,
                Order = order
            };

            return Serialiser.Serialise(actionSettings);
        }
    }
}