﻿namespace DesignPatternsInCsharp.AbstractFactory
{
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    internal class Nokia1600 : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia 1600\nRAM: NA\nCamera: NA\n";
        }
    }
}