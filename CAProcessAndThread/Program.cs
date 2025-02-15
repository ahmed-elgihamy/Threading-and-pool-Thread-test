using System.Diagnostics;

namespace CAProcessAndThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"ProcessId :{Process.GetCurrentProcess().Id}");
            Console.WriteLine($"Thread id :{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Processer id :{Thread.GetCurrentProcessorId}");
        }
    }
}
