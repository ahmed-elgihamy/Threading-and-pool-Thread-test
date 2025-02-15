using System.Diagnostics;

namespace CASequential
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var w = new Wallet("Ahmed", 200);

           w.RunRandmTransction();
           Console.WriteLine(w);
            Console.WriteLine("==================================");
            w.RunRandmTransction();
            Console.WriteLine(w);
        }

        public class Wallet
        {
            public Wallet(string name, int bitcoins)
            {
                Name = name;
                Bitcoins = bitcoins;
            }

            public string Name {  get; private set; }
            public int Bitcoins {  get; private set; }




            public void Depit(int amount)
            {

                Bitcoins -= amount;
            }
            public void Cradit(int amount)
            {

                Bitcoins += amount;
            }

            public void RunRandmTransction()
            {
                int[] amount = { 10, 20, 50, 40, 20, -55, 10, -90, 50, 77, -80 };
                var absvalue = -1;
                foreach (var i in amount)
                {
                    absvalue= Math.Abs(i);

                    if(i > 0)
                    {
                        Cradit(absvalue);
                    }
                    else  
                    {
                        Depit(absvalue);
                    }
                 
                    Console.WriteLine($"processerId ={Thread.GetCurrentProcessorId()}  " +
                                      $"Thread id :{Thread.CurrentThread.ManagedThreadId}  " +
                                      $"amount: {i}");
                }
            }


            public override string ToString()
            {
                return $"{Name} : {Bitcoins}";
                       
            }
        }
    }
}
