using System.Text.RegularExpressions;

namespace DevTrends.MvcDonutCaching
{
    /// <summary>
    /// Describes one donut hole regular expression match in content.
    /// </summary>
    public class DonutMatch
    {
        /// <summary>
        /// Donut hole match.
        /// </summary>
        public Match HoleMatch { get; set; }

        /// <summary>
        /// Index of match in text content, initially equals to <see cref="Match.Index" />. Later shifts during holes
        /// replacing.
        /// </summary>
        public int TextIndex { get; set; }

        /// <summary>
        /// Deserialized action settings for <see cref="HoleMatch" />.
        /// </summary>
        public ActionSettings Settings { get; set; }
    }
}