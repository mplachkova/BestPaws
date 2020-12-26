namespace BestPaws.Data.Models
{
    using System;
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string AuthorEmail { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime? AnsweredOn { get; set; }

        public ICollection<MessagesUsers> MessagesUsers { get; set; }
    }
}
