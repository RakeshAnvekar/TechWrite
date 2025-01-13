using Microsoft.EntityFrameworkCore;
using TechWriteServer.DbContext;
using TechWriteServer.Models.Tag;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Repositories
{
    public class TagRepository: ITagRepository
    {
        #region Private Readonly Properties
        private readonly TechWriteAppDbContext _techWriteAppDbContext;
        #endregion

        #region Constructors
        public TagRepository(TechWriteAppDbContext techWriteAppDbContext)
        {
            _techWriteAppDbContext = techWriteAppDbContext;
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
            }
        }

        public async Task<List<Tag>?> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _techWriteAppDbContext.Tags.ToListAsync(cancellationToken);
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
            }
            return null;
        }
        #endregion
    }
}
