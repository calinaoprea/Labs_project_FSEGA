public partial Classic ProductPage : ContentPage
{
 public ProductPage ()
{
    InitializeComponent();
}
async void OnSaveButtonClicked(object sender, EventArgs e)
{
    var product = (Product)BindingContext;
    wait App.Database.SaveProductAsync(product);
    listView.ItemsSource = await App.Database.GetProductsAsync();
}
async void OnDeleteButtonClicked(object sender, EventArgs e)
{
    var product = listView.SelectedItem as Product;
    wait App.Database.DeleteProductAsync(product);
    listView.ItemsSource = await App.Database.GetProductsAsync();
}
async void OnAddButtonClicked(object sender, EventArgs e)
{
    Product p;
    if (listView.SelectedItem != null)
    {
        p = listView.SelectedItem as Product;
        var lp = new ListProduct()
        {
            ShopListID = sl.ID,
            ProductID = p.ID
        };
        await App.Database.SaveListProductAsync(lp);
        p.ListProducts = new List<ListProduct> { lp };
        await Navigation.PopAsync();
    }
protected override async void onAppearing()
{
    base.OnAppearing();
    listView.ItemsSource = await App.Database.GetProductsAsync();
}
}