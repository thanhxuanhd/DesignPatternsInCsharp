using System;

namespace DesignPatternsInCsharp.AbstractFactory
{
    /// <summary>
    /// The 'ConcreteFactory2' class.
    /// </summary>
    internal class Samsung : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            Console.WriteLine("SamsungGalaxy");
            return new SamsungGalaxy();
        }

        public INormalPhone GetNormalPhone()
        {
            Console.WriteLine("SamsungGuru");
            return new SamsungGuru();
        }
    }
}