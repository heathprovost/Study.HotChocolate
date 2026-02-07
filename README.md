# Study.HotChocolate

Reproduction of issue in HotChocolate.

## Issue 1 - Failure to emit `_entities`

In recent versions of HotChocolate, when using Apollo Federation with a Schema-First development model and ObjectTypeExtensions, The library is failing to add the `_entities` property to Query types in the schema.

In previous versions of HotChocolate (version 13.7.0 for example), the following was added to all Query types as long as there was at least one
Entity in the schema with the `@key` directive:

```csharp
_entities(representations: [_Any!]!): [_Entity]!
```

This property is no longer being added, at least not in v14.x or v15.x of HotChocolate. This breaks functionality with Apollo Federation.

The issue can be demonstrated by running this project, as all it does is
construct a very simple schema-first application and then exports its schema.
The `_entities` property is not being emitted.

## Issue 2 - Duplication of @key directives

Another issue (although not as critical) is that the `@key` directive is
added to the generated schem whenever a TypeExtension calls `descriptor.Key("name")`, even when the underlying schema already declares the directive.

The issue here is that if you omit that call the application will throw this exception:

```csharp
Unhandled exception: HotChocolate.SchemaException: For more details look at the `Errors` property.

1. Unable to find type(s) @key (HotChocolate.Types.ObjectType)
2. Unable to resolve dependencies @key for type `MyClass`. (HotChocolate.Types.ObjectType)
```

In short, The library does not appear to actually work correctly when supplied a schema first, as there should be no reason to call `descrptor.Key()` on a type
that already has a `@key` directive on it in the schema document.

This can be demonstrated by removing `descriptor.Key("id")` from `Study.HotChocolate/Types/MyClassExtensions` and running the project again.
