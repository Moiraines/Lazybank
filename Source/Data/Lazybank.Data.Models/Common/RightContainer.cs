namespace Lazybank.Data.Models
{
    using Lazybank.Data.Common.Models;

    public class RightContainer : BaseModel<int>
    {
        public RightType RightType { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int AccountId { get; set; }

        public virtual BankAccount Account { get; set; }
    }
}
