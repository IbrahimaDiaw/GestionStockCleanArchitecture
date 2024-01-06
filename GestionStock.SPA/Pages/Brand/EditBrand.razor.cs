using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Brand;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace GestionStock.SPA.Pages.Brand
{
    public partial class EditBrand
    {
        [Parameter]
        public string Id { get; set; }
        [Inject] private IBrandManager BrandManager {  get; set; }
        private BrandUpdateRequest _brandModel { get; set; } = new();
        private BrandResponse _brandResponse { get; set; }
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
                _brandResponse = await Http.GetFromJsonAsync<BrandResponse>($"/api/Brand/get-brand-id/{Id}");
                if (_brandResponse != null)
                {
                    SnackBar.Add("Brand get it", Severity.Success);
                    _brandModel = new BrandUpdateRequest { 
                        Id = _brandResponse.Id,
                        Name = _brandResponse.Name,
                        Description = _brandResponse.Description,
                    };
                } 
                else
                {
                    SnackBar.Add("Brand getting is failed", Severity.Error);
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
                var result = await BrandManager.UpdateBrandAsync(Guid.Parse(Id), _brandModel);
                if (result.Successed)
                {
                    SnackBar.Add("Brand update successfully", Severity.Success);
                    Navigation.NavigateTo("/brands");
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
