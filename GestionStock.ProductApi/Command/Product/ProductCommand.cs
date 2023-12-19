using GestionStock.Application.Command;
using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;

namespace GestionStock.ProductApi.Command.Product
{
    public static class ProductCommand
    {
        public class CreateProductCommand : ICommand<ProductResponse>
        {
            public CreateProductCommand(ProductCreateRequest brand)
            {
                Product = brand;
            }

            public ProductCreateRequest Product { get; set; }
        }

        public class UpdateProductCommand : ICommand<ProductResponse>
        {
            public UpdateProductCommand(Guid id, ProductUpdateRequest brand)
            {
                Id = id;
                Product = brand;
            }
            public Guid Id { get; set; }
            public ProductUpdateRequest Product { get; set; }
        }

        public class GetProductCommand : ICommand<ProductResponse>
        {
            public GetProductCommand(Guid id)
            {
                Id = id;
            }
            public Guid Id { get; set; }
        }

        public class GetAllProductCommand : ICommand<List<ProductResponse>>
        {
            public GetAllProductCommand(){}
        }

        public class DeleteCommand : ICommand<ProductResponse>
        {
            public DeleteCommand(Guid id)
            {
                Id = id;
            }
            public Guid Id { get; set; }
        }
    }
}
