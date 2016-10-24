using System;

namespace IGWebApiClient.Common
{
    public interface PropertyEventDispatcher
    {
        void BeginInvoke(Action a);

        void addEventMessage(string message);
    }
}

