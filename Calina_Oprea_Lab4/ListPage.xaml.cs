using Calina_Oprea_Lab4.Models;

public partial Classic ListPage : ContentPage
{
public ListPage ()
{
    InitializeComponent();
}
async void OnSaveButtonClicked(object sender, EventArgs e)
{
    var slist = (ShopList)BindingContext;
    slist.Date = DateTime.UtcNow;
    await App.Database.SaveShopListAsync(list);
    await Navigation.PopAsync();
}
async void OnDeleteButtonClicked(object sender, EventArgs e)
{
    var slist = (ShopList)BindingContext;
    await App.Database.DeleteShopListAsync(list);
    await Navigation.PopAsync();
}
}