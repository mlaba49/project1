using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

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