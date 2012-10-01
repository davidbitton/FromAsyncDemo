using System;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace FromAsyncDemo {
    class Program {
        static void Main() {

            Console.WriteLine("Enter wait time in seconds. Enter 0 to throw an exception.");
            var val = Console.ReadLine();
            int waitSeconds;
            var success = Int32.TryParse(val, out waitSeconds);

            if (success) {

                Console.WriteLine("Starting task at {0}", DateTime.Now);

                var demoService = new DemoService();

                var task =
                    Task.Factory.FromAsync<int, DateTime>(demoService.BeginGetDateTimeAfterWait,
                                                          demoService.EndGetDateTimeAfterWait, waitSeconds, null).
                        ToObservable();

                Console.WriteLine("Task started at {0}. Awaiting a response after {1} seconds.", DateTime.Now,
                                  waitSeconds);

                task
                    .Subscribe(
                        i => Console.WriteLine("DateTime: {0} from task.", i),
                        exception => Console.WriteLine("Exception from task: {0}", exception.Message),
                        () => Console.WriteLine("Operation completed at {0}.", DateTime.Now));
            } else {
                Console.WriteLine("{0} is not a valid interger value.", val);
            }

            Console.WriteLine("Hit any key to end.");
            Console.ReadKey();
        }
    }
}
