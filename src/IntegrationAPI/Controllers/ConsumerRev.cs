
using IntegrationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integration.API.Controllers
{
    [ApiController]
    public class ConsumerRev : Controller
    {
        [HttpGet]
        [Route("api/v1/consumerRev/obterToken")]
        public async Task<IActionResult> ObterToken(string user, string password)
        {
            try
            {
                Login consumer = new Login();

                consumer.ChangeUser(user);
                consumer.ChangePassword(password);

                string apiUrl =  $"http://api.reval.net/api/get-token?username={consumer.User}&password={consumer.Password}";

                HttpClient client = new HttpClient();

                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();

                    // Salvar o token em algum lugar seguro para uso posterior


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
