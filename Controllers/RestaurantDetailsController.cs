using Microsoft.AspNetCore.Mvc;

namespace restaurant.menu_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantDetailsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public RestaurantDetailsController(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        [HttpGet("RestaurantWebSettings")]
        public async Task<IActionResult> GetRestaurantDetails()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://cdn-dev.preoday.com/challenge/venue/9");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ExternalMenu")]
        public async Task<IActionResult> GetExternalMenu()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://cdn-dev.preoday.com/challenge/menu");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
