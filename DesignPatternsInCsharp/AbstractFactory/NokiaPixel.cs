using System;

namespace DesignPatternsInCsharp.AbstractFactory
{
    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    internal class NokiaPixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            Console.WriteLine("GetModelDetails: NokiaPixel");
            return "Model: Nokia Pixel\nRAM: 3GB\nCamera: 8MP\n";
        }
    }
}