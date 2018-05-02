using Prism.Regions;

namespace Altsis.Prism.Extensions
{
    /// <summary>
    /// Represents a region manager aware
    /// </summary>
    public interface IRegionManagerAware
    {
        /// <summary>
        /// Gets or sets the <see cref="IRegionManager"/>
        /// </summary>
        IRegionManager RegionManager { get; set; }
    }
}
