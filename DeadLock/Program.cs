using System.Security.Cryptography;

namespace DeadLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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



        public class TransferManager
        {

            private Wallet from;
            private Wallet to;
            private int amountToTransfer;

            public TransferManager(Wallet from , Wallet to ,int amountToTransfer)
            {
                this.from = from;
                this.to = to;
                this.amountToTransfer = amountToTransfer;
            }



        }
    }
}
