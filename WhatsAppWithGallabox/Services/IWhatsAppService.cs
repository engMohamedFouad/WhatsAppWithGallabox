namespace WhatsAppWithGallabox.Services
{
    public interface IWhatsAppService
    {
        public Task<string> SendTempleteWiothVariablesAsync(string phoneNumber, string customerName);
    }
}
