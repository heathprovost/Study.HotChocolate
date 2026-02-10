# Study.HotChocolate

Reproduction of issue in Hot Chocolate.

## HotChocolate fails to emit `_entities`

In recent versions of Hot Chocolate, when using Apollo Federation and Type Extensions, The library is failing to add the `_entities` property to Query types in the schema.

In previous versions of Hot Chocolate (version 13.7.0 for example), the following was added to all Query types as long as there was at least one Entity in the schema with the `@key` directive:

```
_entities(representations: [_Any!]!): [_Entity]!
```

This property is no longer being added, at least not in versions `14.x` or `15.x` of Hot Chocolate. This breaks functionality with Apollo Federation.

The issue can be demonstrated by running this project, as all it does is
construct a very simple schema-first application and then exports its schema.
The `_entities` property is not being emitted.