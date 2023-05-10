using IntegrationAPI.Models.RevModels;
using Microsoft.AspNetCore.Mvc;

namespace Integration.API.Controllers
{
    [ApiController]
    public class ConsumerRevController : Controller
    {
        [HttpGet]
        [Route("api/v1/consumerRev/getTokenRev")]
        public async Task<IActionResult> GetTokenRev(string user, string password)
        {
            try
            {
                LoginRev consumer = new LoginRev();

                consumer.ChangeUser(user);
                consumer.ChangePassword(password);

                string apiUrl =  $"http://api.reval.net/api/get-token?username={consumer.User}&password={consumer.Password}";

                HttpClient client = new HttpClient();

                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();

                    


                    return Ok("Token obtido com sucesso!");

                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Falha ao obter o token.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter o token: {ex.Message}");
            }
        }
    }
}
