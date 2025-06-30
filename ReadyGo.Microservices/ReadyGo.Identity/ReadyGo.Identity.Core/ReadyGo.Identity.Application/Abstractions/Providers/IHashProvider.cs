namespace ReadyGo.Identity.Application.Abstractions.Providers
{
    public interface IHashProvider
    {
        /// <summary>
        /// Hashes <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Hash(string value);

        /// <summary>
        /// Ensures the equality of the hash <paramref name="value"/> with the <paramref name="hash"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        bool Verify(string value, string hash);
    }
}
