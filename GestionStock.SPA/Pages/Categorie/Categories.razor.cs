using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Category;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.Icons;
using static MudBlazor.CategoryTypes;
using GestionStock.Shared.Request.Category;

namespace GestionStock.SPA.Pages.Categorie
{
    public partial class Categories
    {
        [Inject] private ICategoryManager categoryManager { get; set; }
        [Inject] NavigationManager Navigation { get; set; }
        private List<CategoryResponse> _categories { get; set; } = new List<CategoryResponse>();
        private CategoryCreateRequest _categoryModel { get; set; } = new();
        private CategoryResponse CategoryResult { get; set; } = new ();
        private bool _loading = false;
        private string searchString = "";
        [Inject] ISnackbar snackBar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _categoryModel = new CategoryCreateRequest();
            await GetAllCategories();
        }

        private async Task GetAllCategories()
        {
            try
            {
                _loading = true;
                await Task.Delay(1000);
                var result = await categoryManager.GetAllCategoriesAsync();
                if (result.Successed)
                {
                    _categories = result.Data;
                }
                else
                {
                    result.Messages.ForEach(x => snackBar.Add(x, Severity.Error));
                }
            }
            catch (Exception ex)
            {
                snackBar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                _loading = false;
            }
        }
        private bool SearchFunc(CategoryResponse element) => Seach(element, searchString);

        private bool Seach(CategoryResponse element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)) {
                return true;
            }
            return false;
        }

        private async Task Save()
        {
            try
            {
                _loading = true;
                await categoryManager.SaveCategoryAsync(_categoryModel);
                _categoryModel = new CategoryCreateRequest();
                snackBar.Add("Category saved successfully", Severity.Success);
                await GetAllCategories();
            }
            catch (Exception ex)
            {
                snackBar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                _loading = false;
            }
        }
        private void Edit(string Id)
        {
            Navigation.NavigateTo($"/category/edit/{Id}");
        }
        private void Delete(Guid id)
        {
        }
    }


}
