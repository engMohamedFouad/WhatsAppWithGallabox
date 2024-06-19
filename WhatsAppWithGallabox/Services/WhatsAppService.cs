using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WhatsAppWithGallabox.Helpers;

namespace WhatsAppWithGallabox.Services
{
    public class WhatsAppService : IWhatsAppService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WhatsAppSettings _whatsAppSettings;
        public WhatsAppService(IHttpClientFactory httpClientFactory, WhatsAppSettings whatsAppSettings)
        {
            _httpClientFactory = httpClientFactory;
            _whatsAppSettings = whatsAppSettings;
        }
        public async Task<string> SendTempleteWiothVariablesAsync(string phoneNumber, string customerName)
        {
            var messagePayload = new
            {
                channelId = _whatsAppSettings.ChannelId,
                channelType = "whatsapp",
                recipient = new
                {
                    name = "mohamed Fouad",
                    phone = phoneNumber
                },
                whatsapp = new
                {
                    type = "template",
                    template = new
                    {
                        templateName = "welcome_basic_template",
                        bodyValues = new
                        {
                            customer_name = customerName
                        }
                    }
                }
            };
            var jsonPayload = JsonConvert.SerializeObject(messagePayload);
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("apiKey", _whatsAppSettings.ApiKey);
            client.DefaultRequestHeaders.Add("apiSecret", _whatsAppSettings.ApiSecret);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("https://server.gallabox.com/devapi/messages/whatsapp", new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                return "success";
            else
                return await response.Content.ReadAsStringAsync();
        }
    }
}
