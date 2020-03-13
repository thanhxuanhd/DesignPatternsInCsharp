namespace DesignPatternsInCsharp.AbstractFactory
{
    /// <summary>
    /// The 'Client' class
    /// https://www.c-sharpcorner.com/article/abstract-factory-design-pattern-in-c-sharp/
    /// </summary>
    internal class MobileClient
    {
        private ISmartPhone smartPhone;
        private INormalPhone normalPhone;

        public MobileClient(IMobilePhone factory)
        {
            smartPhone = factory.GetSmartPhone();
            normalPhone = factory.GetNormalPhone();
        }

        public string GetSmartPhoneModelDetails()
        {
            return smartPhone.GetModelDetails();
        }

        public string GetNormalPhoneModelDetails()
        {
            return normalPhone.GetModelDetails();
        }
    }
}