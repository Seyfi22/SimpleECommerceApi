using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus Status { get; private set; }

        public Payment(Guid orderId, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");

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
