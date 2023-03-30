using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;


namespace ChatGpt.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGpt")]
        public async Task<IActionResult> UseChatGpt(string query)
        {
            string result = "";
            var openAi = new OpenAIAPI("YOUR API KEY");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt=query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions=openAi.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Result.Completions)
            {
                result += completion.Text;
            }

            return Ok(result);
        }
    }
}
