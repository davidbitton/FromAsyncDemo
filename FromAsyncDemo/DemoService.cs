using System;
using System.Threading;

namespace FromAsyncDemo {
    public class DemoService : IDemoService {

        private delegate DateTime GetDateTimeAfterWaitInvoker(int waitSeconds);
        private GetDateTimeAfterWaitInvoker _getDateTimeAfterWaitInvoker;

        public DateTime GetDateTimeAfterWait(int waitSecond) {
            if(waitSecond== 0) throw new ArgumentException("Value must be more than 0.", "waitSecond");
            
            Thread.Sleep(waitSecond * 1000);
            return DateTime.Now;
        }

        public IAsyncResult BeginGetDateTimeAfterWait(int waitSecond, AsyncCallback callback, object state) {
            _getDateTimeAfterWaitInvoker = GetDateTimeAfterWait;
            return _getDateTimeAfterWaitInvoker.BeginInvoke(waitSecond, callback, state);
        }

        public DateTime EndGetDateTimeAfterWait(IAsyncResult result) {
            return _getDateTimeAfterWaitInvoker.EndInvoke(result);
        }
    }
}
