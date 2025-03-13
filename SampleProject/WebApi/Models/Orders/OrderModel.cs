using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
