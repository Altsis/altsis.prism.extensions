using Prism.Regions;

namespace Altsis.Prism.Extensions
{
    /// <summary>
    /// Represents information about navigation
    /// </summary>
    public class NavigationInformations
    {
        /// <summary>
        /// Initialize a new instance of <see cref="NavigationInformations"/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        public NavigationInformations(string target, NavigationParameters parameters)
        {
            this.Target = target;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Gets the navigation target
        /// </summary>
        public string Target { get; private set; }

        /// <summary>
        /// Gets the navigation parameters
        /// </summary>
        public NavigationParameters Parameters { get; private set; }
    }
}