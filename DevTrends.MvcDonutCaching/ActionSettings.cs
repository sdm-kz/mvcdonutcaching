﻿using System;
using System.Runtime.Serialization;
using System.Web.Routing;

namespace DevTrends.MvcDonutCaching
{
    [Serializable, DataContract]
    public class ActionSettings
    {
        /// <summary>
        /// Gets or sets the action name.
        /// </summary>
        /// <value>
        /// The action's name.
        /// </value>
        [DataMember(Order = 1)]
        public string ActionName { get; set; }

        /// <summary>
        /// Gets or sets the controller name.
        /// </summary>
        /// <value>
        /// The the controller name.
        /// </value>
        [DataMember(Order = 2)]
        public string ControllerName { get; set; }

        /// <summary>
        /// Gets or sets the route values.
        /// </summary>
        /// <value>
        /// The route values.
        /// </value>
        [DataMember(Order = 3)]
        public RouteValueDictionary RouteValues { get; set; }

        /// <summary>
        /// The ordinal index of action according to it will be invoked.
        /// </summary>
        [DataMember(Order = 4)]
        public int Order { get; set; }
    }
}
