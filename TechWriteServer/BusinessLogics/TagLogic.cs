using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Models.Tag;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.BusinessLogics;

public class TagLogic : ITagLogic
{
    #region Properties
    private readonly ITagRepository _tagRepository;
    #endregion

    #region Constructors
    public TagLogic(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;  
    }
    #endregion

    #region Methods
    public async Task<List<Tag>?> GetAllTagsAsync(CancellationToken cancellationToken)
    {
        return await _tagRepository.GetAllAsync(cancellationToken);
    }
    #endregion
}
