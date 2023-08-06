using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetText(string text)
        {
            string apiKey = "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";
            string response = string.Empty;

            var openai = new OpenAIAPI(apiKey);

            CompletionRequest com = new CompletionRequest();
            com.Prompt = text;
            com.Model = OpenAI_API.Models.Model.DavinciText;
            com.MaxTokens = 200;

            var result = openai.Completions.CreateCompletionAsync(com);

            foreach(var item in result.Result.Completions)
            {
                response = item.Text;
            }

            return Ok(response);
        }
    }
}
