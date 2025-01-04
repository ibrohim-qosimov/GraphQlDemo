# GraphQL Demo

## Run and replace "swagger" with "graphql"

```graphql
query {
  getProducts {
    id
    name
    description
  }
}
```

```graphql
mutation {
  addProduct(name: "Iphone 14 pro max", description: "salam o'rkech") {
    id
    name
    description
  }
}
```
