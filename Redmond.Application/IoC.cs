using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Redmond.Application.Commands;
using Redmond.Application.Queries;
using Redmond.Domain.Commands;
using Redmond.Domain.Queries.GetAllProducts;
using Redmond.Domain.Queries.GetProduct;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application
{
    public static class IoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();

            services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();

            services.AddScoped<IQueryHandler<GetProductFilter, GetProductResult>, GetProductQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllProductsFilter, IEnumerable<GetAllProductsResult>>, GetAllProductsQueryHandler>();
        }
    }
}
