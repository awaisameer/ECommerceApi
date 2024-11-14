using HotChocolate;

namespace ECommerceApi.GraphQL.Types
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Field(c => c.CustomerId).Type<IntType>();
            descriptor.Field(c => c.Name).Type<StringType>();
            descriptor.Field(c => c.Email).Type<StringType>();
            descriptor.Field(c => c.PhoneNumber).Type<StringType>();
            descriptor.Field(c => c.Address).Type<StringType>();
        }
    }
}
