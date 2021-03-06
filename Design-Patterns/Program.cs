﻿using System;
using FactoryMethod = Design_Patterns.FactoryMethod;
using AbstractFactory = Design_Patterns.AbstractFactory;
using Builder = Design_Patterns.Builder;
using Prototype = Design_Patterns.Prototype;
using NaiveSingleton = Design_Patterns.NaiveSingleton;
using ThreadSafeSingleton = Design_Patterns.ThreadSafeSingleton;

namespace Design_Patterns
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Factory Method
            new FactoryMethod.Client().Main();

            // AbstractFactory
            new AbstractFactory.Client().Main();

            // Builder
            new Builder.Client().Main();

            // Prototype
            new Prototype.Client().Main();

            // NaiveSingleton
            new NaiveSingleton.Client().Main();

            // ThreadSafeSingleton
            new ThreadSafeSingleton.Client().Main();
        }
    }
}
