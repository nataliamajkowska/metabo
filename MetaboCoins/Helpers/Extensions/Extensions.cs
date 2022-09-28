using MvvmHelpers;
using System.Linq;
using System.Threading.Tasks;

public static class ExtensionMethods
{
    public static async Task<int> RemoveAllAsync<T>(
        this ObservableRangeCollection<T> coll)
    {
        try
        {
            if (coll != null && coll.Count > 0)
            {
                var itemsToRemove = coll.ToList();

                foreach (var itemToRemove in itemsToRemove)
                {
                    coll.Remove(itemToRemove);
                }
                await Task.Delay(100);
                return itemsToRemove.Count;
            }
            return 0;
        }
        catch
        {
            return 0;
        }
    }
}
