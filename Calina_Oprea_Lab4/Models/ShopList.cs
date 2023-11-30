using SQLite;
namespace Calina_Oprea_Lab4.Models
{
    public Classic ShopList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }
}
}