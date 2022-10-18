namespace CleanArchitecture.Template.RestApi.Setup {
    public static class SwaggerSetup {
        public static void AddSwagger(this IServiceCollection services) {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void UseSwaggerForScooters(this WebApplication app) {
            if (app.Environment.IsProduction())
                return;

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
