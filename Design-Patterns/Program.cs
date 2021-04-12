using System;
using FactoryMethod = Design_Patterns.FactoryMethod;
using AbstractFactory = Design_Patterns.AbstractFactory;
using Builder = Design_Patterns.Builder;

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

            // Builder
            new Builder.Client().Main();
        }
    }
}
