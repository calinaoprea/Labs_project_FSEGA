using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calina_Oprea_Lab4.Models;
namespace Name_Pren_Lab4.Date
{
    public Classic ShoppingListDatabase
    {
 readonly SQLiteAsyncConnection _database;
 public ShoppingListDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<ShopList>().Wait();
    }
    public Task<List<ShopList>> GetShopListsAsync()
    {
        return _database.Table<ShopList>().ToListAsync();
    }
    public Task<ShopList> GetShopListAsync(int id)
    {
        return _database.Table<ShopList>()
       .Where(i => i.ID == id)
       .FirstOrDefaultAsync();
    }
    public Task<int> SaveShopListAsync(ShopList slist)
    {
        if (slist.ID == 0)
        {
            public Task<int> DeleteShopListAsync(ShopList slist)
            {
                return _database.DeleteAsync(list);
            }
        }
        else
        {
            return _database.UpdateAsync(list);


 else
            {
                return _database.InsertAsync(slist);
            }
        }
    }
}