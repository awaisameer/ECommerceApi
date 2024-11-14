using HotChocolate;

namespace ECommerceApi.GraphQL.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Field(p => p.ProductId).Type<IntType>();
            descriptor.Field(p => p.Name).Type<StringType>();
            descriptor.Field(p => p.Price).Type<DecimalType>();
            descriptor.Field(p => p.Description).Type<StringType>();
            descriptor.Field(p => p.StockQuantity).Type<IntType>();
        }
    }
}
