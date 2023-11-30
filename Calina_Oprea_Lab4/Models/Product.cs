using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Calina_Oprea_Lab4.Models
{
    public class productively
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<ListProduct> ListProducts { get; set; }
    }
}