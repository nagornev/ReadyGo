namespace ReadyGo.Identity.Application.Abstractions.Providers
{
    public interface ITFASecretProvider
    {
        /// <summary>
        /// Creates two factor authentication secret.
        /// </summary>
        /// <returns></returns>
        string Create();
    }
}
