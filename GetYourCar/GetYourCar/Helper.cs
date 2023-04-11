using GetYourCar.Models;

namespace GetYourCar;

public class Helper
{
    private static PostgresContext _db;

    public static PostgresContext GetContext()
    {
        if (_db == null)
        {
            _db = new PostgresContext();
        }

        return _db;
    }
}
