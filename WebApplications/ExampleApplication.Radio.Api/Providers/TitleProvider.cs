namespace ExampleApplication.Radio.Api.Providers
{
    internal class TitleProvider : AssemblyInfoProvider, ITitleProvider
    {
        public string Title => GetAssemblyInfo().ProductTitle;
    }
}