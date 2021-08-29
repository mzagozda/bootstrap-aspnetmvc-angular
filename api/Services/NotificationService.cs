using System;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private string qualifier;
        private readonly string emailTitle;
        private string emailBody;
        private StringBuilder message;
        
        public NotificationService()
        { 
            DateTime date = DateTime.UtcNow;
            decimal half = DateTime.DaysInMonth(date.Year, date.Month) / 2;
            qualifier = DateTime.UtcNow.Day <= Math.Round(half, MidpointRounding.AwayFromZero) ? "Middle" : "End";
           
            emailTitle = $"<h1>Info about days till {qualifier} of the month</h1>";

            emailBody = "<p>Body placeholder<p>";
            message = new StringBuilder();
            message.AppendLine(emailTitle);
            message.AppendLine(emailBody);
        }
        
        
        /// <summary>
        /// Sends e-mail message based on title and body
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SendEmail()
        {
            // throw new NotImplementedException();    
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Sends a message based on a message object consisting of body followed by a title
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SendMessage()
        {
            // throw new NotImplementedException();    
            return await Task.FromResult(true);
        }
        
        
    }
}
