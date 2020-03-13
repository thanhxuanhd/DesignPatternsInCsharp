namespace DesignPatternsInCsharp.AbstractFactory
{
    /// <summary>
    /// The 'AbstractFactory' interface.
    /// </summary>
    internal interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();

        INormalPhone GetNormalPhone();
    }
}