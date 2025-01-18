using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaAsync.ViewModels;

namespace AvaloniaAsync;

public partial class DataControl : UserControl
{
    DataViewModel _dataViewModel;

    public DataControl()
    {
        InitializeComponent();
        DataContext = new DataViewModel();
        _dataViewModel = (DataViewModel)DataContext;
    }

    public async void ClickHandlerAsync(object sender, RoutedEventArgs args)
    {
        await _dataViewModel.LoadCompaniesAsync();
    }


    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        _dataViewModel.LoadCompanies();
    }
}



