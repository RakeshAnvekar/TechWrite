using TechWriteServer.Helpers.Interfaces;

namespace TechWriteServer.Helpers;

public class DateTimeConverterHelper : IDateTimeConverterHelper
{
    #region Methods
    public async Task<string?> ConvertToUtcAsync(DateTime dateTime)
    {
        return await Task.FromResult(dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
    }
    #endregion
}
