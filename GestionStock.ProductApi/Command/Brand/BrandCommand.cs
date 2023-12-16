using GestionStock.Application.Command;
using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;

namespace GestionStock.ProductApi.Command.Brand
{
    public static class BrandCommand
    {
        public class CreateBrandCommand : ICommand<BrandResponse>
        {
            public CreateBrandCommand(BrandCreateRequest brand)
            {
                Brand = brand;
            }

            public BrandCreateRequest Brand { get; set; }
        }

        public class UpdateBrandCommand : ICommand<BrandResponse>
        {
            public UpdateBrandCommand(Guid id, BrandUpdateRequest brand)
            {
                Id = id;
                Brand = brand;
            }
            public Guid Id { get; set; }
            public BrandUpdateRequest Brand { get; set; }
        }

        public class GetBrandCommand : ICommand<BrandResponse>
        {
            public GetBrandCommand(Guid id)
            {
                Id = Id;
            }
            public Guid Id { get; set; }
        }

    }
}
