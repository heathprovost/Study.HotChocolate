using Study.HotChocolate.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
  .AddApolloFederation()
  .AddDocumentFromFile("./schema.gql")
  .BindRuntimeType<Query>()
  .BindRuntimeType<MyClass>("MyClass")
  .AddTypeExtension<MyClassExtensions>()
  .InitializeOnStartup();

var app = builder.Build();

app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);
