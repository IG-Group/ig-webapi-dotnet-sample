using System;
using System.Windows;
using System.Windows.Threading;

namespace IGWebApiClient.Common
{
    public interface PropertyEventDispatcher
    {
        void BeginInvoke(Action a);

        void addEventMessage(string message);
    }
}

