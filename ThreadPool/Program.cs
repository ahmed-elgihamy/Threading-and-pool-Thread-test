using System.Threading;
namespace ThreadPooll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using ThreadPool");

            // 1
            //  ThreadPool.QueueUserWorkItem(new WaitCallback(Print) );

            //    Console.WriteLine("Using Task");

            // 2
            //   Task.Run(Print);
            //      Console.ReadKey();

            Employee emp = new Employee (500,200);
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetCalcu), emp);

        }

        private static void GetCalcu(object Employee)
        {
            var emp = (Employee)Employee;
            Console.WriteLine($"Total salary {emp.salary + emp.bounc}");
        }

        private static void Print()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }

        private static void Print(object state)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }


        class Employee
        {

            public int salary { get; set; }
            public int bounc { get; set; }
            public Employee(int sal, int bo) { salary = sal; bounc = bo; }

        } 
    }
}
