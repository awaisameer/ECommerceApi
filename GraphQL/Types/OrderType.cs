using HotChocolate;

namespace ECommerceApi.GraphQL.Types
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Field(o => o.OrderId).Type<IntType>();
            descriptor.Field(o => o.CustomerId).Type<IntType>();
            descriptor.Field(o => o.OrderDate).Type<DateTimeType>();
            descriptor.Field(o => o.TotalAmount).Type<DecimalType>();
        }
    }
}
