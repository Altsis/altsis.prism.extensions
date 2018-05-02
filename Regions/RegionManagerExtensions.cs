using Microsoft.Practices.Unity;
using Prism.Regions;
using System;

namespace Altsis.Prism.Extensions.Regions
{
    /// <summary>
    /// Class that creates a fluent interface for the <see cref="IRegionManager"/> class, with respect to 
    /// adding views to regions (View Injection pattern), registering view types to regions (View Discovery pattern)
    /// </summary>
    public static class RegionManagerExtensions
    {
        /// <summary>
        /// Navigates the specified region manager.
        /// </summary>
        /// <param name="regionManager">The regionmanager that this extension method effects.</param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="source">The URI of the content to display.</param>
        /// <param name="navigationCallback">The navigation callback.</param>
        /// <param name="containerToUse">The IUnityContainer to use, which could be the main application container or a child container.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, Uri source, Action<NavigationResult> navigationCallback, IUnityContainer container)
        {
            if (regionManager == null) throw new ArgumentNullException("regionManager");
            if (navigationCallback == null) throw new ArgumentNullException("navigationCallback");
            if (container == null) throw new ArgumentNullException("container");

            if (regionManager.Regions.ContainsRegionWithName(regionName))
            {
                regionManager.Regions[regionName].RequestNavigate(source, navigationCallback, container);
            }
            else
            {
                navigationCallback(new NavigationResult(new NavigationContext(null, source), false));
            }
        }

        /// <summary>
        /// Navigates the specified region manager.
        /// </summary>
        /// <param name="regionManager">The regionmanager that this extension method effects.</param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="source">The URI of the content to display.</param>
        /// <param name="containerToUse">The IUnityContainer to use, which could be the main application container or a child container.</param>
        public static void RequestNavigateUsingSpecificContainer(this IRegionManager regionManager, string regionName, Uri source, IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            RequestNavigate(regionManager, regionName, source, e => { }, container);
        }

        /// <summary>
        /// Navigates the specified region manager.
        /// </summary>
        /// <param name="regionManager">The regionmanager that this extension method effects.</param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="source">The URI of the content to display.</param>
        /// <param name="navigationCallback">The navigation callback.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string source, Action<NavigationResult> navigationCallback, IUnityContainer container)
        {
            if (source == null) throw new ArgumentNullException("source");

            RequestNavigate(regionManager, regionName, new Uri(source, UriKind.RelativeOrAbsolute), navigationCallback, container);
        }

        /// <summary>
        /// Navigates the specified region manager.
        /// </summary>
        /// <param name="regionManager">The regionmanager that this extension method effects.</param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="source">The URI of the content to display.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string source, IUnityContainer container)
        {
            RequestNavigate(regionManager, regionName, source, nr => { }, container);
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target Uri, passing a navigation callback and an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A Uri that represents the target where the region will navigate.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters, IUnityContainer container)
        {
            if (regionManager == null)
            {
                return;
            }

            if (regionManager.Regions.ContainsRegionWithName(regionName))
            {
                regionManager.Regions[regionName].RequestNavigate(target, navigationCallback, navigationParameters, container);
            }
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target string, passing a navigation callback and an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A string that represents the target where the region will navigate.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters, IUnityContainer container)
        {
            RequestNavigate(regionManager, regionName, new Uri(target, UriKind.RelativeOrAbsolute), navigationCallback, navigationParameters, container);
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target Uri, passing an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A Uri that represents the target where the region will navigate.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, Uri target, NavigationParameters navigationParameters, IUnityContainer container)
        {
            RequestNavigate(regionManager, regionName, target, nr => { }, navigationParameters, container);
        }

        /// <summary>
        /// This method allows an IRegionManager to locate a specified region and navigate in it to the specified target string, passing an instance of NavigationParameters, which holds a collection of object parameters.
        /// </summary>
        /// <param name="regionManager">The IRegionManager instance that is extended by this method.</param>
        /// <param name="regionName">The name of the region where the navigation will occur.</param>
        /// <param name="target">A string that represents the target where the region will navigate.</param>
        /// <param name="navigationParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target, NavigationParameters navigationParameters, IUnityContainer container)
        {
            RequestNavigate(regionManager, regionName, new Uri(target, UriKind.RelativeOrAbsolute), nr => { }, navigationParameters, container);
        }
    }
}
