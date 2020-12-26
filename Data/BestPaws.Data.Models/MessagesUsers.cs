namespace BestPaws.Data.Models
{
    using BestPaws.Data.Common.Models;

    public class MessagesUsers : BaseDeletableModel<int>
    {
        public int MessageId { get; set; }

        public Message Message { get; set; }

        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
