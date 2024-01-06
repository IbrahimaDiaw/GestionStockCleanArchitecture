using GestionStock.Shared.Common;
using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.Brand
{
    public class BrandManager(HttpClient httpClient) : IBrandManager
    {
        private readonly HttpClient _httpClient = httpClient;

        public Task<IResult<bool>> DeleteBrandAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<List<BrandResponse>>> GetAllBrandsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Brand/get-all-brands");
                return await response.ToResult<List<BrandResponse>>();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IResult<bool>> SaveBrandAsync(BrandCreateRequest request)
        {
            try
            {
               var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Brand/create-brand", content);
                return await response.ToResult<bool>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IResult<BrandResponse>> UpdateBrandAsync(Guid Id, BrandUpdateRequest request)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"/api/Brand/update-brand/{Id}", content);
                return await response.ToResult<BrandResponse>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
