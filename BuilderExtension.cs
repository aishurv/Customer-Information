namespace CustomerInformation
{
    public static class BuilderExtension
    {
        public static void AddBuilderServices(this WebApplicationBuilder builder)
        {
             builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        }
    }
}
