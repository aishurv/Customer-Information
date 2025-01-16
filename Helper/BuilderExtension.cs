namespace CustomerInformation.Helper
{
    public static class BuilderExtension
    {
        /// <summary>
        /// Add Services to the WebApplicationBuilder builder
        /// </summary>
        /// <param name="builder"></param>
        public static void AddBuilderServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorComponents()
           .AddInteractiveServerComponents();
        }
    }
}
