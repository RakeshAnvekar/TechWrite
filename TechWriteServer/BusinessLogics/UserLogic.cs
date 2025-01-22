using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Helpers;
using TechWriteServer.Helpers.Interfaces;
using TechWriteServer.Models.User;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.BusinessLogics;

public class UserLogic : IUserLogic
{
    #region Properties
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherHelper _passwordHasherHelper;
    #endregion

    #region Constructors
    public UserLogic(IUserRepository userRepository, IPasswordHasherHelper passwordHasherHelper)
    {
        _userRepository = userRepository;
        _passwordHasherHelper = passwordHasherHelper;
    }   
    #endregion

    #region Methods
    public async Task<User?> RegisterUserAsync(User user, CancellationToken cancellationToken)
    {
        if(user == null) throw new ArgumentNullException(nameof(user));
        user.Password = await _passwordHasherHelper.HashPasswordAsync(user.Password);

        return await _userRepository.CreateAsync(user, cancellationToken);
    }
    public async Task<List<User>?> GetAllUserAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }

    public async Task<User?> LoginAsync(User user, CancellationToken cancellationToken)
    {       
       return await _userRepository.IsUserExistsAsync(user, cancellationToken);
    }

    public async Task<string?> GetUserNameAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(userId,cancellationToken);
        return (user == null || user.UserName == null) ? null : user.UserName;
    }
    #endregion
}
