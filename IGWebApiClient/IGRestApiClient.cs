using System;
using System.Net.Http;
using System.Threading.Tasks;
using dto.endpoint.auth.session.v2;
using dto.endpoint.auth.encryptionkey;
using dto.endpoint.browse;
using dto.endpoint.watchlists.retrieve;
using IGWebApiClient.Common;
using IGWebApiClient.Security;

namespace IGWebApiClient
{
    public partial class IgRestApiClient
	{
        private PropertyEventDispatcher eventDispatcher;
        private ConversationContext _conversationContext;

        private IgRestService _igRestService;

        public IgRestApiClient(string environment, PropertyEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
            this._igRestService = new IgRestService(eventDispatcher, environment);
        }


        private EncryptionKeyResponse ekr { get; set; }

        public ConversationContext GetConversationContext()
        {
            return _conversationContext;
        }

        public async Task<IgResponse<AuthenticationResponse>> SecureAuthenticate(AuthenticationRequest ar, string apiKey)
        {
            _conversationContext = new ConversationContext(null, null, apiKey);
            var encryptedPassword = await SecurePassword(ar.password);

            if (encryptedPassword == ar.password)
            {
                ar.encryptedPassword = false;
            }
            else
            {
                ar.encryptedPassword = true;
            }
            ar.password = encryptedPassword;
            return await authenticate(ar);
        }

        private async Task<string> SecurePassword(string rawPassword)
        {
            var encryptedPassword = rawPassword;


            //Try encrypting password. If we can encrypt it, do so...                                                                            
            var secureResponse = await fetchEncryptionKey();

            ekr = new EncryptionKeyResponse();
            ekr = secureResponse.Response;

            if (ekr != null)
            {
                byte[] encryptedBytes;

                // get a public key to ENCRYPT...
                Rsa rsa = new Rsa(Convert.FromBase64String(ekr.encryptionKey), true);

                encryptedBytes = rsa.RsaEncrypt(string.Format("{0}|{1}", rawPassword, ekr.timeStamp));
                encryptedPassword = Convert.ToBase64String(encryptedBytes);
            }
            return encryptedPassword;
        }

		///<Summary>
		///Creates a trading session, obtaining session tokens for subsequent API access.
		///<p>
		///   Please note that region-specific <a href=/loginrestrictions>login restrictions</a> may apply.
		///</p>
		///@param authenticationRequest Client login credentials
		///@return Client summary account information
		///</Summary>

		public async Task<IgResponse<dto.endpoint.auth.session.v2.AuthenticationResponse>> authenticate(dto.endpoint.auth.session.v2.AuthenticationRequest authenticationRequest) 
		{
			return await _igRestService.RestfulService<dto.endpoint.auth.session.v2.AuthenticationResponse>("/gateway/deal/session", HttpMethod.Post, "2", _conversationContext, authenticationRequest);
		}


		///<Summary>
		///Creates a trading session, obtaining session tokens for subsequent API access
		///@return the encryption key to be used to encode the credentials
		///</Summary>

		public async Task<IgResponse<EncryptionKeyResponse>> fetchEncryptionKey() 
		{
			return await _igRestService.RestfulService<EncryptionKeyResponse>("/gateway/deal/session/encryptionKey", HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Log out of the current session
		///</Summary>

		public async void logout() 
		{
			await _igRestService.RestfulService("/gateway/deal/session", HttpMethod.Delete, "1", _conversationContext);
		}

		///<Summary>
		///Returns all top-level nodes (market categories) in the market navigation hierarchy.
		///</Summary>

		public async Task<IgResponse<BrowseMarketsResponse>> browseRoot() 
		{
			return await _igRestService.RestfulService<BrowseMarketsResponse>("/gateway/deal/marketnavigation", HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns all sub-nodes of the given node in the market navigation hierarchy
		///@return the children of the selected node
		///@throws BrowseMarketsException
		///@pathParam nodeId the identifier of the node to browse
		///</Summary>

		public async Task<IgResponse<BrowseMarketsResponse>> browse(string nodeId) 
		{
			return await _igRestService.RestfulService<BrowseMarketsResponse>("/gateway/deal/marketnavigation/" + nodeId, HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns all open positions for the active account
		///</Summary>

		public async Task<IgResponse<dto.endpoint.positions.get.otc.v2.PositionsResponse>> getOTCOpenPositionsV2() 
		{
			return await _igRestService.RestfulService<dto.endpoint.positions.get.otc.v2.PositionsResponse>("/gateway/deal/positions", HttpMethod.Get, "2", _conversationContext);
		}

		///<Summary>
		///Returns all watchlists belonging to the active account
		///</Summary>

		public async Task<IgResponse<ListOfWatchlistsResponse>> listOfWatchlists() 
		{
			return await _igRestService.RestfulService<ListOfWatchlistsResponse>("/gateway/deal/watchlists", HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns the given watchlists markets
		///@pathParam watchlistId Watchlist id
		///</Summary>

		public async Task<IgResponse<WatchlistInstrumentsResponse>> instrumentsForWatchlist(string watchlistId) 
		{
			return await _igRestService.RestfulService<WatchlistInstrumentsResponse>("/gateway/deal/watchlists/" + watchlistId, HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns all open working orders for the active account
		///</Summary>

		public async Task<IgResponse<dto.endpoint.workingorders.get.v2.WorkingOrdersResponse>> workingOrdersV2() 
		{
			return await _igRestService.RestfulService<dto.endpoint.workingorders.get.v2.WorkingOrdersResponse>("/gateway/deal/workingorders", HttpMethod.Get, "2", _conversationContext);
		}
	}
}
