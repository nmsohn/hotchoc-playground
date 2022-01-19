# hotchoc-playground

## Query
```
query{
  items
  {
    id
    title
  }
}
```

### Filtering
```
query {
  lists(where: {id: {eq: 1} })
  {
    id
    name
    todoItems {
      title
    }
  }
}
```

### Sorting
```
query{
  lists(order: {name: DESC})
  {
    id
    name
  }
}
```

## Mutation
```
mutation{
  addList(request: {
    name: "Work"
  })
  {
    list
    {
      name
    }
  }
}
```

```
mutation{
  addItem(request: {
    title: "Bring laptop",
    description: "Bring the laptop with charger",
    done: true,
    todoListId: 1
  })
  {
    item
    {
      id
      title
    }
  }
}
```

[Reference](https://dev.to/moe23/net-5-api-with-graphql-step-by-step-2b20)
