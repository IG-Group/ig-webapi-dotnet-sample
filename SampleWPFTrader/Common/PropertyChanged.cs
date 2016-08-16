using IGWebApiClient.Common;

namespace SampleWPFTrader.Common
{
    public class PropertyChanged : PropertyChangedBase
    {

        private static PropertyEventDispatcher eventDispatcher = SmartDispatcher.getInstance();

        /// <summary>
        /// Notify any listeners that the property value has changed.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(propertyName, ref eventDispatcher);
        }
    }
}
