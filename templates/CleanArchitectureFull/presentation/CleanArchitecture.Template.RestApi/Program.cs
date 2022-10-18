using CleanArchitecture.Template.RestApi.Setup;

await WebApplication.CreateBuilder(args)
                    .SetupApplication()
                    .ConfigureHttpRequestPipeline()
                    .RunAsync();