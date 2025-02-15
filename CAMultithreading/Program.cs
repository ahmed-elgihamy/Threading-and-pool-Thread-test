namespace CAMultithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = " thread main";

            var wal = new Wallet("Ahmed Mamoud",80);

          //  Console.WriteLine("current Thread :"+ Thread.CurrentThread.Name);
          //  Console.WriteLine("bg threads :"+ Thread.CurrentThread.IsBackground);

            Thread t1 = new Thread(wal.RunRandmTransction);
      
            t1.Name = "t1";
            Console.WriteLine($"After Daclartion {t1.Name}  stats is {t1.ThreadState}");
            t1.Start();
            t1.Join();
            Thread t2 = new Thread(new ThreadStart(wal.RunRandmTransction));
            t2.Name = "t2";
         
            t2.Start();
            Console.WriteLine($"After Daclartion {t1.Name}  stats is {t1.ThreadState}");
            Console.WriteLine($"After Daclartion {t2.Name}  stats is {t2.ThreadState}");


        }

        public class Wallet
        {
            public Wallet(string name, int bitcoins)
            {
                Name = name;
                Bitcoins = bitcoins;
            }

            public string Name { get; private set; }
            public int Bitcoins { get; private set; }




            public void Depit(int amount)
            {

                Bitcoins -= amount;

                Console.WriteLine($"processerId ={Thread.GetCurrentProcessorId()}  " +
                                  $"Thread :{Thread.CurrentThread.ManagedThreadId}+ {Thread.CurrentThread.Name}  " +
                                  $"  - amount   ");
            }
            public void Cradit(int amount)
            {

                Bitcoins += amount;

                Console.WriteLine($"processerId ={Thread.GetCurrentProcessorId()}  " +
                               $"Thread :{Thread.CurrentThread.ManagedThreadId}+ {Thread.CurrentThread.Name}  " +
                               $"  + amount   ");
            }

            public void RunRandmTransction()
            {
                int[] amount = { 10, 20, 50, 40, 20, -55, 10, -90, 50, 77, -80 };
                var absvalue = -1;
                foreach (var i in amount)
                {
                    absvalue = Math.Abs(i);

                    if (i > 0)
                    {
                        Cradit(absvalue);
                    }
                    else
                    {
                        Depit(absvalue);
                    }

                }
            }


            public override string ToString()
            {
                return $"{Name} : {Bitcoins}";

            }
        }
    }
}
