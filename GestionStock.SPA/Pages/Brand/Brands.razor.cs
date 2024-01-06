using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Brand;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.Icons;
using static MudBlazor.CategoryTypes;

namespace GestionStock.SPA.Pages.Brand
{
    public partial class Brands
    {
        [Inject] private IBrandManager brandManager { get; set; }
        [Inject] NavigationManager Navigation { get; set; }
        private List<BrandResponse> _brands { get; set; } = new List<BrandResponse>();
        private BrandCreateRequest _brandModel { get; set; } = new();
        private BrandResponse BrandResult { get; set; } = new ();
        private bool _loading = false;
        private string searchString = "";
        [Inject] ISnackbar snackBar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _brandModel = new BrandCreateRequest();
            await GetAllBrands();
        }

        private async Task GetAllBrands()
        {
            try
            {
                _loading = true;
                await Task.Delay(1000);
                var result = await brandManager.GetAllBrandsAsync();
                if (result.Successed)
                {
                    _brands = result.Data;
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
        private bool SearchFunc(BrandResponse element) => Seach(element, searchString);

        private bool Seach(BrandResponse element, string searchString)
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
               await brandManager.SaveBrandAsync(_brandModel);
                //if (result.Successed)
                //{
                    _brandModel = new BrandCreateRequest();
                    snackBar.Add("Brand saved successfully", Severity.Success);
                    await GetAllBrands();
                //}
                //else
                //{
                //    result.Messages.ForEach(x => snackBar.Add(x, Severity.Error));
                //}
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
            Navigation.NavigateTo($"/brand/edit/{Id}");
        }
        private void Delete(Guid id)
        {
        }
    }


}
