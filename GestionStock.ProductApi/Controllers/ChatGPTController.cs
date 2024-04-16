using GestionStock.Shared.Common;
using GestionStock.Shared.Request.ChatGPT;
using GestionStock.Shared.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using static GestionStock.ProductApi.Command.Product.ProductCommand;

namespace GestionStock.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ChatGPTController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("prompt")]
        public async Task<ActionResult<PromptReponse>> ChatPrompt(PromptRequest prompt)
        {
            await Task.CompletedTask;
            string apiKey = _configuration["OpenAI:ApiKey"]!;
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt.Message;
            completion.Model = OpenAI_API.Models.Model.Davinci;
            completion.Temperature = 0.7;
            completion.TopP = 1;
            completion.FrequencyPenalty = 0;
            completion.PresencePenalty = 0;
            completion.Echo = true;
            completion.MaxTokens = 4000;
            var result = openai.Completions.CreateCompletionAsync(completion);
            if (result != null)
            {
                foreach (var item in result.Result.Completions)
                {
                    answer += item.Text;
                }
                var promptResult = new PromptReponse
                {
                    Message = answer,
                    TextSeach = prompt.Message,
                };
                return Ok(await Result<PromptReponse>.SuccessAsync(promptResult));
            }
            else
            {
                return BadRequest("Not found");
            }
        }
    }
}
