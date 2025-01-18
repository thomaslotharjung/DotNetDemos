namespace CallbackDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Program....");
            Console.WriteLine("Calling long running operation....");

            // Call the method that simulates an async operation, passing a delegate (callback) to be called when the operation is complete
            SimulateAsyncMethod(CallbackMethod);

            for (int i = 0; i < 5; i++)
            {
                Task.Delay(1000).Wait();
                Console.WriteLine($"doing something else...");
            }
        }

        static void CallbackMethod(string result)
        {
            Console.WriteLine(result);
        }

        // Simulates an async/await pattern, but using a callback (delegate)
        static void SimulateAsyncMethod(Action<string> callback)
        {
            // Start a task that simulates some async operation
            Task.Run(async () =>
            {
                Console.WriteLine("Starting async operation...");

                // Simulate some work (e.g., waiting for 2 seconds)
                await Task.Delay(3000);  // Simulate async work using Task.Delay

                // Call the callback method once the "async" operation is complete
                callback("Operation complete");
            });
        }
    }
}
