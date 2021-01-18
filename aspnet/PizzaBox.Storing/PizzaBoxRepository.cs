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
      List<string> result = new List<string>();
      foreach(Order o in _ctx.Order) {
        string orderString = o.ToString();
        foreach(Pizza p in _ctx.APizzaModel) {
          if(p.OrderEntityId == o.EntityId) orderString += "\n" + p.ToString();
        }
        result.Add(orderString);
      }
      return result;
    }
    public List<string> GetOrdersByUser(string user)
    {
      List<string> result = new List<string>();
      foreach(User u in _ctx.Users) {
        foreach(Order o in _ctx.Order) {
          if(o.UserEntityId == u.EntityId && u.Name == user) {
            result.Add(o.ToString());
            foreach(Pizza p in _ctx.APizzaModel) {
              if(p.OrderEntityId == o.EntityId) result.Add(p.ToString());
            }
          }
          
        }
      }
      
      return result;
    }
    public List<string> GetOrdersByStore(string store)
    {
      List<string> result = new List<string>();
      foreach(Store s in _ctx.Stores) {
        foreach(Order o in _ctx.Order) {
          if(o.StoreEntityId == s.EntityId && s.Name == store) {
            result.Add(o.ToString());
            foreach(Pizza p in _ctx.APizzaModel) {
              if(p.OrderEntityId == o.EntityId) result.Add(p.ToString());
            }
          }
          
        }
      }
      
      return result;
    }
  }
}