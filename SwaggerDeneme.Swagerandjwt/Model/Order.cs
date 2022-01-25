using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.Swagerandjwt.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
        public string UserId { get; set; }
        public int TableId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UserQuota { get; set; }
    }
}
