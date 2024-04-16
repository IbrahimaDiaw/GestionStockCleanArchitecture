using GestionStock.Shared.Common;
using GestionStock.Shared.Request.ChatGPT;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.ChatGPT
{
    public interface IChatGPTManager
    {
        Task<IResult<PromptReponse>> GenerativeAI(PromptRequest prompt);
    }
}
