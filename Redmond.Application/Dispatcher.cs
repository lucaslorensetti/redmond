using System;
using System.Threading.Tasks;
using Redmond.SharedKernel.Dtos;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<OperationResult> DoAsync(ICommand command)
        {
            var type = typeof(ICommandHandler<>);
            var typeArgs = new Type[] { command.GetType() };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = this.serviceProvider.GetService(handlerType);
         
            return await handler.HandleAsync((dynamic)command);
        }

        public async Task<T> GetAsync<T>(IQuery query)
        {
            var type = typeof(IQueryHandler<,>);
            var typeArgs = new Type[] { query.GetType(), typeof(T) };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = this.serviceProvider.GetService(handlerType);
            
            return await handler.HandleAsync((dynamic)query);
        }
    }
}
