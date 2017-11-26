using IAWeb.Domain.Services;

namespace IAWeb.Infra.Services
{
    class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            // System.Net.Mail => Enviar E-mail
        }
    }
}
