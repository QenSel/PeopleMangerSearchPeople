using PeopleManager.Ui.Mvc.ApiServices.Extensions;
using PeopleManager.Ui.Mvc.Stores;

namespace PeopleManager.Ui.Mvc.ApiServices.Handlers
{
    public class AuthorizationHttpHandler: DelegatingHandler
    {
        private readonly TokenStore _tokenStore;

        public AuthorizationHttpHandler(TokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _tokenStore.GetToken();

            request.AddAuthorization(token);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
