using Study.HotChocolate.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
  .AddApolloFederation()
  .AddType<Query>()
  .AddType<MyClass>()
  .AddTypeExtension<MyClassExtensions>()
  .InitializeOnStartup();

var app = builder.Build();

app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);
