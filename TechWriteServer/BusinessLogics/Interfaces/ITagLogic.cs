using TechWriteServer.Models.Tag;

namespace TechWriteServer.BusinessLogics.Interfaces;

public interface ITagLogic
{
    #region Methods
    public Task<List<Tag>?> GetAllTagsAsync(CancellationToken cancellationToken);
    #endregion
}
