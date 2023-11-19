using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class Message
    {
        public ConcurrentQueue<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {
            var t = to.Select(t => new MailboxAddress("Cesar Schultz", t));
            To = new ConcurrentQueue<MailboxAddress>(t);
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
