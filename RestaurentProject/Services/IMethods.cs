using RestaurentProject.ViewModel;
using System.Collections.Generic;

namespace RestaurentProject.Services
{
    public interface IMethods
    {
        bool IsAvaliable(int id);
        float ConvertToUSD(float nis);
        string CapFirstChar(string Name);
        List<CsvModelView> GetCsvData();
    }
}
