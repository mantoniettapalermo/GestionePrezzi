using System.Configuration;

namespace GestionePrezziCore
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
