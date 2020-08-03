using E_Commerce.Dtos;
using System.Collections.Generic;

namespace E_Commerce.Services.Contracts
{
    public interface IOrderService
    {
        OrderDto Create(List<int> ids, string username);

        List<OrderDto> UserOrders(string username);

        string ChangeOrderStatus(int id, string status);
    }
}
