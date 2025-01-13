using Microsoft.EntityFrameworkCore;
using TechWriteServer.DbContext;
using TechWriteServer.Enums;
using TechWriteServer.Helpers.Interfaces;
using TechWriteServer.Models.Blog;
using TechWriteServer.Models.User;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Repositories;

public class UserRepository:IUserRepository
{
    #region Private Readonly Properties
    private readonly TechWriteAppDbContext _techWriteAppDbContext;
    private readonly IPasswordHasherHelper _passwordHasherHelper;
    #endregion

    #region Constructors
    public UserRepository(TechWriteAppDbContext techWriteAppDbContext, IPasswordHasherHelper passwordHasherHelper)
    {
        _techWriteAppDbContext = techWriteAppDbContext;
        _passwordHasherHelper = passwordHasherHelper;
    }   

    #endregion

    #region Public Methods
    public async Task<List<User>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _techWriteAppDbContext.Users.ToListAsync(cancellationToken);
    }

    public async Task<User?> GetAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _techWriteAppDbContext.Users.FirstOrDefaultAsync(user=>user.UserId == userId,cancellationToken);
    }

    public async Task<User?> CreateAsync(User user, CancellationToken cancellationToken)
    {
       user.UserTypeId = (int)UserTypes.User;
       await _techWriteAppDbContext.Users.AddAsync(user, cancellationToken);
       var result = await _techWriteAppDbContext.SaveChangesAsync();
        if (result > 0)
        {
            return user;
        }
        return null;
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken)
    {

      var existingUser=  await _techWriteAppDbContext.Users.FindAsync(userId);
        if (existingUser!=null)
        {
            _techWriteAppDbContext.Users.Remove(existingUser);
            await _techWriteAppDbContext.SaveChangesAsync();
        }
    }

    public async Task<User?> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        if(user==null) throw new ArgumentNullException(nameof(user));

        var userDetails = await _techWriteAppDbContext.Users.FindAsync(user.UserId);
        if (userDetails != null)
        {
            userDetails.UserPhoneNo = user.UserPhoneNo;
            userDetails.UserEmailId = user.UserEmailId;
            userDetails.UserName = user.UserName;
            userDetails.isActive = user.isActive;
            userDetails.Password = user.Password;
            userDetails.ProfilePicture = user.ProfilePicture;
            await _techWriteAppDbContext.SaveChangesAsync();
            return user;
        }
        return null;
    }

    public async Task<User?> IsUserExistsAsync(User user, CancellationToken cancellationToken)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        if (string.IsNullOrEmpty(user.UserEmailId)) throw new ArgumentNullException(nameof(user));

        if (string.IsNullOrEmpty(user.Password)) throw new ArgumentNullException(nameof(user));

        var userExists = await _techWriteAppDbContext.Users.FirstOrDefaultAsync(x => x.UserEmailId == user.UserEmailId ,cancellationToken);
        if (userExists != null && await _passwordHasherHelper.VerifyPasswordAsync(userExists.Password, user.Password))
        {         
            userExists.IsUserLoggedIn = true;
            await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
            return userExists;
        }
        return null;
    }

    #endregion
}
