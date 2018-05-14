using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBear.Models.Repositories
{
    public interface IItemRepository
    {
        IQueryable<Review> Reviews { get; }
        IQueryable<Item> Items { get; }
        Item Create(Item item);
        Item Edit(Item item);
        void Delete(int id);
        void DeleteAll();
    }
}