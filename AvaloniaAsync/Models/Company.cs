using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaAsync.Models;

public class Company : ObservableObject
{
    private int _id;
    private string _name = string.Empty;
    public int Id
    {
        get { return _id; }
        set { SetProperty(ref _id, value); }
    }
    public string Name
    {
        get { return _name; }
        set { SetProperty(ref _name, value); }
    }
}
