namespace GraphQlDemo.Mutations;

public class Mutation
{
    public string CreateProduct(string name)
    {
        return $"Product '{name}' created successfully!";
    }
}