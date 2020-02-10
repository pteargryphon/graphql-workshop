using Chat.Server.DataLoader;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace Chat.Server.Types
{
    public class ViewerType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                .Name("Viewer")
                .AsNode()
                .IdField(t => t.Id)
                .NodeResolver((ctx, id) =>
                    ctx.DataLoader<UserByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }
    }
}