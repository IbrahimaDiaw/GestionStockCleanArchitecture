using GestionStock.Shared.Common;
using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.Product
{
    public class ProductManager (HttpClient httpClient) : IProductManager
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IResult<bool>> DeleteProductAsync(Guid Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiUrlConstantes.DeleteProductApiUrl}/{Id}");
                return await response.ToResult<bool>();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IResult<List<ProductResponse>>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiUrlConstantes.GetAllProductApiUrl);
                return await response.ToResult<List<ProductResponse>>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IResult<bool>> SaveProductAsync(ProductCreateRequest request)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ApiUrlConstantes.CreateProductApiUrl, content);
                return await response.ToResult<bool>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IResult<ProductResponse>> UpdateProductAsync(Guid Id, ProductUpdateRequest request)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{ApiUrlConstantes.UpdateProductApiUrl}/{Id}", content);
                return await response.ToResult<ProductResponse>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
