using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Category;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace GestionStock.SPA.Pages.Categorie
{
    public partial class EditCategory
    {
        [Parameter]
        public string Id { get; set; }
        [Inject] private ICategoryManager CategoryManager {  get; set; }
        private CategoryUpdateRequest _categoryModel { get; set; } = new();
        private CategoryResponse _categoryResponse { get; set; }
        [Inject] ISnackbar SnackBar { get; set; }
        [Inject] NavigationManager Navigation {  get; set; }
        [Inject] HttpClient Http {  get; set; }
        private bool _loading = false;

        protected override async Task OnInitializedAsync()
        {
            await Get();
        }
        private async Task Get()
        {
            try
            {
                _loading = true;
                _categoryResponse = await Http.GetFromJsonAsync<CategoryResponse>($"/api/Category/get-category-id/{Id}");
                if (_categoryResponse != null)
                {
                    SnackBar.Add("Category get it", Severity.Success);
                    _categoryModel = new CategoryUpdateRequest { 
                        Id = _categoryResponse.Id,
                        Name = _categoryResponse.Name,
                        Description = _categoryResponse.Description,
                    };
                } 
                else
                {
                    SnackBar.Add("Category getting is failed", Severity.Error);
                }
            }
            catch (Exception ex)
            {
                SnackBar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                _loading = false;
            }

        }
        private async Task Update()
        {
            try
            {
                _loading = true;
                var result = await CategoryManager.UpdateCategoryAsync(Guid.Parse(Id), _categoryModel);
                if (result.Successed)
                {
                    SnackBar.Add("Category update successfully", Severity.Success);
                    Navigation.NavigateTo("/categories");
                }
                else
                {
                    result.Messages.ForEach(x => SnackBar.Add(x, Severity.Error));
                }
            }
            catch (Exception ex)
            {
                SnackBar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                _loading = false;
            }
        }
    }
}
