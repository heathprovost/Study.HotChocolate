using HotChocolate.ApolloFederation.Types;

namespace Study.HotChocolate.Types;

public class MyClass
{
  public string Id { get; set; } = "123";
}

public class MyClassExtensions : ObjectTypeExtension<MyClass>
{
  protected override void Configure(IObjectTypeDescriptor<MyClass> descriptor)
  {
    descriptor.Name("MyClass");
    descriptor.Key("id");
  }
}