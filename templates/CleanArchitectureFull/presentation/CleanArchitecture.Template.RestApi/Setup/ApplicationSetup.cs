namespace CleanArchitecture.Template.RestApi.Setup {
    public static class ApplicationSetup {
        public static WebApplication SetupApplication(this WebApplicationBuilder builder) {
            var services = builder.Services;

            services.AddControllers();
            services.AddDependencyInjection();
            services.AddSwagger();

            return builder.Build();
        }

        public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app) {
            app.UseCustomSwagger();
            app.UseRouting();
            app.MapControllers();

            return app;
        }
    }
}
