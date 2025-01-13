namespace TechWriteServer.Helpers.Interfaces;

public interface IDateTimeConverterHelper
{
    #region Methods
    public Task <string?> ConvertToUtcAsync(DateTime dateTime);
    #endregion
}
