using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleECommerceApi.Domain.Enums;
using SimpleECommerceApi.Domain.ValueObjects;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public Money Amount { get; private set; }
        public PaymentStatus Status { get; private set; }

        public Payment(Guid orderId, Money amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Id = Guid.NewGuid();
            OrderId = orderId;
            PaymentDate = DateTime.UtcNow;
            Amount = amount;
            Status = PaymentStatus.Pending;
        }

        public void UpdateStatus(PaymentStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
