using CustomerInformation.Model;
using Serilog;

namespace CustomerInformation.Helper
{
    public static class ListExtension
    {
        public static List<T> SearchCustomer<T>(this List<T> TList, string AttributeName, string AttributeValue)
        {
            Log.Information($"Find {AttributeValue} of {AttributeName}");
            var Property = typeof(T).GetProperty(AttributeName);
            if (Property == null)
            {
                return TList;
            }
            if (AttributeValue == null)
            {
                AttributeValue = string.Empty;
            }
            TList = TList.Where(c =>
            {
                var value = Property.GetValue(c)?.ToString() ?? string.Empty;
                return value.Equals(AttributeValue, StringComparison.OrdinalIgnoreCase);
            }).ToList();
            return TList;
        }
        public static List<T> SortCustomers<T>(this List<T> TList,string AttributeName, bool IsDesc)
        {
            var Property = typeof(Customer).GetProperty(AttributeName);
            if (Property == null)
                return TList;
            if (IsDesc)
                return TList.OrderByDescending(c => Property.GetValue(c, null)).ToList();
            return TList.OrderBy(c => Property.GetValue(c, null)).ToList();
        }
    }
}
