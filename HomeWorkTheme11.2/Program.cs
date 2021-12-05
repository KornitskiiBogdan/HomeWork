using System;

namespace HomeWorkTheme11._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.M();
            I1 i = (I1)b;
            i.M();
            I2 I = (I2)b;
            I.M();
        }
    }

    interface I1
    {
        void M();
    }

    interface I2
    {
        void M();
    }

    class A : I1, I2
    {
        void I1.M()
        {
            Console.WriteLine("I1 in A");
        }
        void I2.M()
        {
            Console.WriteLine("I2 in A");
        }
        public void M() { Console.WriteLine("A.M()"); }
    }

    class B : A, I1, I2
    {
        void I1.M()
        {
            Console.WriteLine("I1 in B");
        }
        void I2.M()
        {
            Console.WriteLine("I2 in B");
        }
    }
}
// * Задание 2
//
// Есть код:
//
// Ознакомиться с кодом в файле A.cs
// Реализовать интерфейсы I1, I2 в классе A
//
////// Реализовать интерфейсы I1, I2 в классе B
//