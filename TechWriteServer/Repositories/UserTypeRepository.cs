using Microsoft.EntityFrameworkCore;
using TechWriteServer.DbContext;
using TechWriteServer.Models.User;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Repositories;

public class UserTypeRepository : IUserTypeRepository
{
    #region Private Readonly Properties

    private readonly TechWriteAppDbContext _techWriteAppDbContext;

    #endregion

    #region Constructors
    public UserTypeRepository(TechWriteAppDbContext techWriteAppDbContext)
    {
        _techWriteAppDbContext = techWriteAppDbContext ?? throw new ArgumentNullException(nameof(techWriteAppDbContext));
    }
    #endregion

    #region Public Methods
    public async Task<IEnumerable<UserType>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _techWriteAppDbContext.UserTypes.ToListAsync(cancellationToken);
    }
    public async Task<UserType?> GetAsync(int userTypeId, CancellationToken cancellationToken)
    {
        return await _techWriteAppDbContext.UserTypes.FirstOrDefaultAsync(x => x.UserTypeId == userTypeId,cancellationToken);
    }
    public async Task CreateAsync(UserType userType, CancellationToken cancellationToken)
    {
        if(userType==null) throw new ArgumentNullException(nameof(userType));

      await _techWriteAppDbContext.UserTypes.AddAsync(userType,cancellationToken);
      await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(int userTypeId, CancellationToken cancellationToken)
    {
       var userType = await _techWriteAppDbContext.UserTypes.FindAsync(userTypeId, cancellationToken);
        if (userType != null)
        {
           _techWriteAppDbContext.UserTypes.Remove(userType);
           await _techWriteAppDbContext.SaveChangesAsync();
        }
    }
    public async Task<UserType?> UpdateAsync(UserType userType, CancellationToken cancellationToken)
    {
        if (userType == null) throw new ArgumentNullException(nameof(userType));

        var existingUserType= await _techWriteAppDbContext.UserTypes.FindAsync(userType.UserTypeId, cancellationToken);
        if (existingUserType != null) {
            existingUserType.Type=userType.Type;
            await _techWriteAppDbContext.SaveChangesAsync();
            return userType;
        }
        return null;
    }
    
    #endregion

}
