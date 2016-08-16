using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IGWebApiClient.Common
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// A static set of argument instances, one per property name.
        /// </summary>
        private static Dictionary<string, PropertyChangedEventArgs> _argumentInstances = new Dictionary<string, PropertyChangedEventArgs>();

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify any listeners that the property value has changed.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        public void RaisePropertyChanged(string propertyName, ref PropertyEventDispatcher eventDispatcher)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("PropertyName cannot be empty or null.");
            }

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs args;
                if (!_argumentInstances.TryGetValue(propertyName, out args))
                {
                    args = new PropertyChangedEventArgs(propertyName);
                    _argumentInstances[propertyName] = args;
                }

                // Fire the change event. The smart dispatcher will directly
                // invoke the handler if this change happened on the UI thread,
                // otherwise it is sent to the proper dispatcher.
                eventDispatcher.BeginInvoke(delegate
                {
                    handler(this, args);
                });
            }
        }
    }
}
