using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace LandmarkDevs.Core.Shared
{
    public interface IChangeTrackingModel : INotifyPropertyChanged
    {
        /// <summary> Resets this object. </summary>
        void Reset();

        /// <summary> Tracks the changed value. </summary>
        /// <exception cref="System.ArgumentException">
        ///  Thrown when one or more arguments have unsupported or illegal values. </exception>
        /// <param name="value"> The value. </param>
        /// <param name="propertyName">
        ///  (Optional)
        ///  Name of the property.
        ///  </param>
        void TrackChange(object value, [CallerMemberName] string propertyName = null);

        /// <summary> True if this object has changes. </summary>
        bool HasChanges { get; }

        /// <summary>Gets or sets the changes.</summary>
        /// <value>The changes.</value>
        ConcurrentDictionary<string, object> Changes { get; set; }

        /// <summary> Gets changed value. </summary>
        /// <param name="propertyName"> Name of the property. </param>
        /// <returns> The changed value. </returns>
        object GetChangedValue(string propertyName);

        /// <summary>
        /// Occurs when the property is modified.
        /// </summary>
        event PropertyChangedEventHandler OnModified;

        /// <summary>
        /// Raises the on modified event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        void RaiseOnModified(string propertyName);
    }
}