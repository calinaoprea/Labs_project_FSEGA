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
        _database.CreateTableAsync<Product>().Wait();
        _database.CreateTableAsync<ListProduct>().Wait();
    }
    public Task<int> SaveListProductAsync(ListProduct listp)
    {
        if (listp.ID != 0)
        {
            return _ database.UpdateAsync(listp);
        }
        else
        {
            return _ database.InsertAsync(listp);
        }
    }
    public Task<List<Product>> GetListProductsAsync(int shoplistid)
    {
        return _ database.QueryAsync<Product>(
        " select P.ID, P.Description from Product P"
       + "inner join ListProduct LP"
       + " on P.ID = LP.ProductID where LP.ShopListID = ?",
        shoplistid);
    }
}
}
