namespace TechWriteServer.Helpers.Interfaces;

public interface IPasswordHasherHelper
{
    #region Methods
    /// <summary>
    /// Hashes the provided password using a secure hashing algorithm (e.g., PBKDF2).
    /// The password is salted and hashed to ensure it is stored securely.
    /// </summary>
    /// <param name="password">The plain text password to be hashed.</param>
    /// <returns>A securely hashed version of the provided password.</returns>
    Task<string> HashPasswordAsync(string password);
    /// <summary>
    /// Verifies if the provided password matches the stored hashed password.
    /// It uses the original salt to hash the provided password and compares the result with the stored hash.
    /// </summary>
    /// <param name="hashedPassword">The stored hashed password (with salt).</param>
    /// <param name="providedPassword">The password provided by the user to verify.</param>
    /// <returns>True if the provided password matches the hashed password; otherwise, false.</returns>

    Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword);
    #endregion
}
