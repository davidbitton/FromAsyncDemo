using System;

namespace FromAsyncDemo {
    public interface IDemoService {
        DateTime GetDateTimeAfterWait(int waitSecond);
        IAsyncResult BeginGetDateTimeAfterWait(int waitSecond, AsyncCallback callback, object state);
        DateTime EndGetDateTimeAfterWait(IAsyncResult result);
    }
}