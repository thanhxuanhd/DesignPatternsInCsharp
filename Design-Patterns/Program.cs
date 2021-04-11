using System;
using FactoryMethod = Design_Patterns.FactoryMethod;
using AbstractFactory = Design_Patterns.AbstractFactory;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Factory Method
            new FactoryMethod.Client().Main();

            // AbstractFactory
            new AbstractFactory.Client().Main();
        }
    }
}
