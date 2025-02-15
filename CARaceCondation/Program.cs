namespace CARaceCondation
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Wallet w = new Wallet("ahmed",50);
            var T1 = new Thread(() => w.Depit(40));
            var T2 = new Thread(() => w.Depit(20));
            T1.Start();
            T2.Start();


            T1.Join();
            T2.Join();



            Console.WriteLine(w);


        }

        public class Wallet
        {

            private readonly object _lock = new object();
            public Wallet(string name, int bitcoins)
            {
                Name = name;
                Bitcoins = bitcoins;
            }

            public string Name { get; private set; }
            public int Bitcoins { get; private set; }




            public void Depit(int amount)
            {
                lock (_lock)
                {
                    if (Bitcoins >= amount)
                    {
                        Thread.Sleep(1000);
                        Bitcoins -= amount;
                    }
                }
            }
            public void Cradit(int amount)
            {
                Thread.Sleep(1000);
                Bitcoins += amount;
            }

       
            public override string ToString()
            {
                return $"{Name} : {Bitcoins}";

            }
        }
    }
}
