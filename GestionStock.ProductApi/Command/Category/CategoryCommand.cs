using GestionStock.Application.Command;
using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;

namespace GestionStock.ProductApi.Command.Category
{
    public static class CategoryCommand
    {
        public class CreateCategoryCommand : ICommand<CategoryResponse>
        {
            public CreateCategoryCommand(CategoryCreateRequest brand)
            {
                Category = brand;
            }

            public CategoryCreateRequest Category { get; set; }
        }

        public class UpdateCategoryCommand : ICommand<CategoryResponse>
        {
            public UpdateCategoryCommand(Guid id, CategoryUpdateRequest brand)
            {
                Id = id;
                Category = brand;
            }
            public Guid Id { get; set; }
            public CategoryUpdateRequest Category { get; set; }
        }

        public class GetCategoryCommand : ICommand<CategoryResponse>
        {
            public GetCategoryCommand(Guid id)
            {
                Id = id;
            }
            public Guid Id { get; set; }
        }

        public class GetAllCategoryCommand : ICommand<List<CategoryResponse>>
        {
            public GetAllCategoryCommand(){}
        }

        public class DeleteCommand : ICommand<bool>
        {
            public DeleteCommand(Guid id)
            {
                Id = id;
            }
            public Guid Id { get; set; }
        }
    }
}
