using GestionStock.Shared.Common;
using GestionStock.Shared.Request.ChatGPT;
using GestionStock.Shared.Response;
using GestionStock.SPA.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.ChatGPT
{
    public class ChatGPTManager(HttpClient httpClient) : IChatGPTManager
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task<IResult<PromptReponse>> GenerativeAI(PromptRequest prompt)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(prompt);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ApiUrlConstantes.ChatGPTPromptApiUrl, content);
                return await response.ToResult<PromptReponse>();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
