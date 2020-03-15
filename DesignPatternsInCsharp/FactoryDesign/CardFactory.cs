namespace DesignPatternsInCsharp.FactoryDesign
{
    /// <summary>
    /// The 'Creator' Abstract Class
    /// </summary>
    internal abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
}