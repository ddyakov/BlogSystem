namespace BlogSystem.Data.Services.Implementation
{
    using System.Threading.Tasks;
    using Contracts;
    using Microsoft.AspNet.Identity;

    public class SmsService : ISendProvider
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }
}
