namespace Study.HotChocolate.Types;

public class Query
{
  public MyClass? MyClass(CancellationToken cancellationToken)
  {
    return new MyClass { Id = "123" };
  }
}
