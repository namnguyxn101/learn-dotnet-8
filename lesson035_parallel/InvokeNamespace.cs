namespace InvokeNamespace
{
    class DemoInvoke
    {
        //In thông tin, Task ID và thread ID đang chạy
        public static void PintInfo(string info) => 
        Console.WriteLine($"{info, 10}    task:{Task.CurrentId,3}    " + $"thread: {Thread.CurrentThread.ManagedThreadId}");
        
        public static async void RunTask(string s)  {
            PintInfo($"Start {s,10}"); 
            await Task.Delay(1000);           
            PintInfo($"Finish {s,10}");   
        }

        public static void actionA() {
            PintInfo($"Finish {"ActionA",10}");  
        }

        public static void actionB() {
            PintInfo($"Finish {"ActionB",10}");  
        }


        public static void ParallelInvoke() {
            Action action1  = () => {
                RunTask("Action1");
            };

            Parallel.Invoke(action1, actionA, actionB);
        }
        public static void RunDemo()
        {
            ParallelInvoke();
            Console.WriteLine("Press any key ..."); 
            Console.ReadKey(); 
        }
    }
}