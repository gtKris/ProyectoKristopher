using PortafolioKristopher.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PortafolioKristopher.Service
{
    public interface IServiceEmail 
    {
        Task Send(ContactViewModel contact);
    }

    public class ServicesEmailSendGrid : IServiceEmail
    {
        private readonly IConfiguration configuration;

        public ServicesEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(ContactViewModel contact)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"El cliente {contact.Email} quiere contactarte";
            var to = new EmailAddress(email, name);
            var comments = contact.Comments;
            var contentsHtml = @$"De: {contact.Name} - Email {contact.Email} Comments: {contact.Comments}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, comments, contentsHtml);
            var response = await client.SendEmailAsync(singleEmail);

        }
    }
}
