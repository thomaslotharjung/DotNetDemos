

using AvaloniaAsync.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AvaloniaAsync.ViewModels;

public class DataViewModel : ObservableObject
{
    private ObservableCollection<Company> _companies = new();

    string _demoText = "";
    DateTime _currentTime = DateTime.Now;

    public DataViewModel()
    {
        Task.Run(Start);
    }

    public DateTime CurrentTime
    {
        get { return _currentTime; }
        set { SetProperty(ref _currentTime, value); }
    }
    public string DemoText
    {
        get
        {
            return _demoText;
        }

        set
        {
            SetProperty(ref _demoText, value);
        }
    }

    public ObservableCollection<Company> Companies
    {
        get => _companies;
        set
        {
            SetProperty(ref _companies, value);
        }
    }


    private async void Start()
    {
        while (true)
        {
            CurrentTime = DateTime.Now;
            await Task.Delay(1000);
        }
    }

    public async Task LoadCompaniesAsync()
    {
        DemoText = "Loading companies...";
        // Simulate async data loading (e.g., from a database or API)
        await Task.Delay(5000); // Simulating delay

        ObservableCollection<Company> companies = GetCompanies();

        Companies = companies;
        DemoText = "Companies loaded!";
    }

    public void LoadCompanies()
    {
        DemoText = "Loading companies...";
        // Simulate async data loading (e.g., from a database or API)
        Task.Delay(5000).Wait(); // Simulating delay

        ObservableCollection<Company> companies = GetCompanies();

        Companies = companies;
        DemoText = "Companies loaded!";
    }

    private ObservableCollection<Company> GetCompanies()
    {
        ObservableCollection<Company> companies = new ObservableCollection<Company>();
        Random random = new Random();
        int count = random.Next(10, 20);

        for (int i = 1; i <= count; i++)
        {
            companies.Add(new Company
            {
                Id = i,
                Name = $"Company {i}"
            });
        }

        return companies;
    }
}
