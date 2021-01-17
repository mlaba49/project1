using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxRepository
  {
    private PizzaBoxContext _ctx;

    public PizzaBoxRepository(PizzaBoxContext context)
    {
      _ctx = context;
    }

    public List<string> GetStores()
    {
      return _ctx.Stores.Select(s => s.Name).ToList();
    }
    public List<string> GetUsers()
    {
      return _ctx.Users.Select(u => u.Name).ToList();
    }
    public List<string> GetPizzas()
    {
      return _ctx.APizzaModel.Select(p => p.ToString()).ToList();
    }
    public List<string> GetPizzasByUser(string user) {
      List<string> result = new List<string>();
      foreach(var pizza in _ctx.APizzaModel) {
        foreach(var order in _ctx.Order) {
          if(pizza.OrderEntityId == order.EntityId) {
            foreach(var customer in _ctx.Users) {
              if(order.UserEntityId == customer.EntityId && customer.Name == user) result.Add(pizza.ToString());
            }
          }
        }
      }
      return result;
    }
    public List<string> GetPizzasByStore(string store) {
      List<string> result = new List<string>();
      foreach(var pizza in _ctx.APizzaModel) {
        foreach(var order in _ctx.Order) {
          if(pizza.OrderEntityId == order.EntityId) {
            foreach(var _store in _ctx.Stores) {
              if(order.StoreEntityId == _store.EntityId && _store.Name == store) result.Add(pizza.ToString());
            }
          }
        }
      }
      return result;
    }
    public List<string> GetOrders()
    {
      return _ctx.Order.Select(o => o.ToString()).ToList();
    }

    // public IEnumerable<T> Get<T>() where T : AModel
    // {
    //   return _ctx.Set<T>().Select(t => t.GetType().GetProperty()).ToList();
    // }
  }
}