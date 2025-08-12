using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerceApi.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,      // Sifariş yaradılıb, amma təsdiqlənməyib
        Processing = 1,   // Hazırlanır / paketlənir
        Shipped = 2,      // Çatdırılma prosesindədir
        Delivered = 3,    // Çatdırılıb
        Cancelled = 4     // İmtina edilib
    }
}
