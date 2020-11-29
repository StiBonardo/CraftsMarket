
namespace CraftsMarket.Data.Models
{
    using System;

    using CraftsMarket.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class Message : BaseDeletableModel<string>
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Content { get; set; }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
    }
}
