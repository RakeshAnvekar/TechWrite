using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TechWriteServer.DbContext;
using TechWriteServer.Models.Tag;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Repositories
{
    public class TagRepository: ITagRepository
    {
        #region Private Readonly Properties
        private readonly TechWriteAppDbContext _techWriteAppDbContext;
        private readonly IMemoryCache _memoryCache;
        const string tagCacheKey = "TagCacheKey";
        #endregion

        #region Constructors
        public TagRepository(TechWriteAppDbContext techWriteAppDbContext, IMemoryCache memoryCache)
        {
            _techWriteAppDbContext = techWriteAppDbContext;
            _memoryCache = memoryCache;
        }


        #endregion

        #region Public Methods
        public async Task CreateAsync(Tag tag, CancellationToken cancellationToken)
        {  
            if(tag == null) throw new ArgumentNullException(nameof(tag));

           await _techWriteAppDbContext.Tags.AddAsync(tag,cancellationToken);
           await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int tagId, CancellationToken cancellationToken)
        {
            if(tagId < 0) throw new ArgumentOutOfRangeException(nameof(tagId));

           var existingTag=await _techWriteAppDbContext.Tags.FindAsync(tagId,cancellationToken);
            if (existingTag != null)
            {
                _techWriteAppDbContext.Tags.Remove(existingTag);
               await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
                DeleteTagsDataFromCache();
            }
        }

        public async Task<List<Tag>?> GetAllAsync(CancellationToken cancellationToken)
        {
           
            // Try to get tags from the cache
            if (!_memoryCache.TryGetValue(tagCacheKey, out List<Tag>? tags))
            {
                  tags = await _techWriteAppDbContext.Tags.ToListAsync(cancellationToken);
                _memoryCache.Set(tagCacheKey, tags);
            }

            // Return the tags (either from cache or DB)
            return tags;
        }

        public async Task<Tag?> GetAsync(int tagId, CancellationToken cancellationToken)
        {
            if(tagId<0) throw new ArgumentOutOfRangeException(nameof(tagId));

            return await _techWriteAppDbContext.Tags.FindAsync(tagId, cancellationToken);
        }

        public async Task<Tag?> UpdateAsync(Tag tag, CancellationToken cancellationToken)
        {
            if(tag==null) throw new ArgumentNullException(nameof(tag));

            var existingTag = await _techWriteAppDbContext.Tags.FindAsync(tag.TagId,cancellationToken);
            if (existingTag != null) { 
            existingTag.TagName=tag.TagName;
               await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
                DeleteTagsDataFromCache();
            }
            return null;
        }

        private void DeleteTagsDataFromCache()
        {
            _memoryCache.Remove(tagCacheKey);
        }
        #endregion
    }
}
