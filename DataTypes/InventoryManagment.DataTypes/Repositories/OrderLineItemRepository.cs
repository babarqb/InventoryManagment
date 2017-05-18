using System;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class OrderLineItemRepository : Repository<OrderLineItem>, IOrderLineItemRepository
    {
        public OrderLineItemRepository(DbContext context) : base(context)
        {

        }
    }
}