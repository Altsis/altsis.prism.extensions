﻿using Microsoft.Practices.Unity;
using Prism.Regions;
using System;

namespace Altsis.Prism.Extensions.Regions
{
    /// <summary>
    /// From post : http://www.codeproject.com/Articles/640573/ViewModel-st-Child-Container-PRISM-Navigation
    /// </summary>
    public static class RegionExtensions
    {
        public static void RequestNavigate(this IRegion region,
    Uri target, Action<NavigationResult> navigationCallback,
    IUnityContainer container)
        {
            RequestNavigate(region, target, navigationCallback, null, container);
        }

        public static void RequestNavigate(this IRegion region,
Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters,
IUnityContainer container)
        {
            CustomRegionNavigationService customRegionNavigationService = region.NavigationService as CustomRegionNavigationService;
            if (customRegionNavigationService == null)
                throw new InvalidOperationException(
                    "RequestNavigate that takes a container may only be used with a CustomRegionNavigationService");

            customRegionNavigationService.RequestNavigate(target, navigationCallback, navigationParameters, container);
        }
    }
}
