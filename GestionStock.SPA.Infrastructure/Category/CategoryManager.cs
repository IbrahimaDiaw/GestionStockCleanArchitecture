
using GestionStock.Shared.Common;
using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.Category
{
    public class CategoryManager(HttpClient httpClient) : ICategoryManager
    {
        private readonly HttpClient _httpClient = httpClient;

        public Task<IResult<bool>> DeleteCategoryAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<IResult<List<CategoryResponse>>> GetAllCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Category/get-all-categories");
                return await response.ToResult<List<CategoryResponse>>();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IResult<bool>> SaveCategoryAsync(CategoryCreateRequest request)
        {
            try
            {
               var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Category/create-category", content);
                return await response.ToResult<bool>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IResult<CategoryResponse>> UpdateCategoryAsync(Guid Id, CategoryUpdateRequest request)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"/api/Category/update-category/{Id}", content);
                return await response.ToResult<CategoryResponse>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
