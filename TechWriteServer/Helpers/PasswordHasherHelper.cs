using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using TechWriteServer.Helpers.Interfaces;

namespace TechWriteServer.Helpers;
public sealed class PasswordHasherHelper : IPasswordHasherHelper
{
    #region Private Properties

    #endregion

    #region Constructors
    #endregion

    #region Methods
    public async Task<string> HashPasswordAsync(string password)
    {
        var salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            salt,
            KeyDerivationPrf.HMACSHA256,
            10000,
            32));
        return await Task.FromResult(Convert.ToBase64String(salt.Concat(Encoding.UTF8.GetBytes(hash)).ToArray()));       
    }

    public async Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword)
    {
        var salt =  Convert.FromBase64String(hashedPassword).Take(16).ToArray();
        var storedHash = Convert.FromBase64String(hashedPassword).Skip(16).ToArray();
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            providedPassword,
            salt,
            KeyDerivationPrf.HMACSHA256,
            10000,
            32));
       return await Task.FromResult(storedHash.SequenceEqual(Encoding.UTF8.GetBytes(hash)));
    }
    #endregion
}
