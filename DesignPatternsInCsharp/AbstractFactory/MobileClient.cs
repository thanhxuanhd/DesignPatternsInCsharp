namespace DesignPatternsInCsharp.AbstractFactory
{
    /// <summary>
    /// The 'Client' class
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