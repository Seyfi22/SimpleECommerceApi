using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending = 0,   // Ödəniş gözləmədədir
        Completed = 1, // Ödəniş uğurla tamamlanıb
        Failed = 2,    // Ödəniş uğursuz olub
        Refunded = 3   // Pul geri qaytarılıb
    }
}
