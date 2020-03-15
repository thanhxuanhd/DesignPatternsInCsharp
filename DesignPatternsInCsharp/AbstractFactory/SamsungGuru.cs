using System;

namespace DesignPatternsInCsharp.AbstractFactory
{
    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    internal class SamsungGuru : INormalPhone
    {
        public string GetModelDetails()
        {
            Console.WriteLine("GetModelDetails: SamsungGuru");
            return "Model: Samsung Guru\nRAM: NA\nCamera: NA\n";
        }
    }
}