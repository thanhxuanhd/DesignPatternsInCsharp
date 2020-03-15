using System;

namespace DesignPatternsInCsharp.AbstractFactory
{
    internal class Nokia : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            Console.WriteLine("NokiaPixel");
            return new NokiaPixel();
        }

        public INormalPhone GetNormalPhone()
        {
            Console.WriteLine("Nokia1600");
            return new Nokia1600();
        }
    }
}