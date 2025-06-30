namespace ReadyGo.Identity.Application.Abstractions.Providers
{
    public interface IVersionProvider
    {
        /// <summary>
        /// Creates authentication version.
        /// </summary>
        /// <returns></returns>
        Guid Create();
    }
}
