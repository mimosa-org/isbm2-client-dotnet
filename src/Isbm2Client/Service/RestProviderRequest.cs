﻿using Isbm2Client.Interface;
using Isbm2Client.Model;

using RestApi = Isbm2RestClient.Api;
using RestModel = Isbm2RestClient.Model;
using RestClient = Isbm2RestClient.Client;
using Microsoft.Extensions.Options;

namespace Isbm2Client.Service
{
    public class RestProviderRequest : IProviderRequest
    {
        private readonly RestApi.ProviderRequestServiceApi _requestApi;

        public RestProviderRequest(IOptions<ClientConfig> options)
        {
            RestClient.Configuration apiConfig = new()
            {
                BasePath = options.Value.EndPoint
            };

            // TODO: proper configuration

            _requestApi = new RestApi.ProviderRequestServiceApi(apiConfig);
        }

        public async Task<RequestProviderSession> OpenSession(RequestChannel channel, IEnumerable<string> topics) 
        {
            var sessionParams = new RestModel.Session()
            {
                SessionType = RestModel.SessionType.RequestProvider,
                Topics = topics.ToList(),
                FilterExpressions = new List<RestModel.FilterExpression>()
            };

            var session = await _requestApi.OpenProviderRequestSessionAsync( channel.Uri, sessionParams );

            if ( session is null ) throw new Exception( "Uh oh" );

            return new RequestProviderSession( session.SessionId, sessionParams.ListenerUrl, sessionParams.Topics.ToArray(), Array.Empty<string>() );
        }

        public async Task<RequestMessage> ReadRequest(RequestProviderSession session)
        {
            var response = await _requestApi.ReadRequestAsync( session.Id );

            MessageContent messageContent = response.MessageContent.Content.ActualInstance switch
            {
                string x => 
                    new MessageContent<string>( response.MessageId, x),

                Dictionary<string, object> x => 
                    new MessageContent<Dictionary<string, object>>( response.MessageId, x ),

                _ => 
                    throw new Exception( "Uh oh" )
            };

            return new RequestMessage( response.MessageId, messageContent, response.Topics.ToArray(), "" );
        }

        public async Task<ResponseMessage> PostResponse<T>( RequestProviderSession session, RequestMessage requestMessage, T content )
        {
            var inputMessageContent = content switch
            {
                string x =>
                    new RestModel.MessageContent("text/plain", content: new RestModel.MessageContentContent(x)),

                Dictionary<string, object> x =>
                    new RestModel.MessageContent("application/json", content: new RestModel.MessageContentContent(x)),

                _ =>
                    throw new ArgumentException("Invalid content found. Must be the following types: Dictionary<string, object>, string")
            };

            var inputMessage = new RestModel.Message( messageContent: inputMessageContent );

            var message = await _requestApi.PostResponseAsync( session.Id, requestMessage.Id, inputMessage );

            Model.MessageContent messageContent = content switch
            {
                string x => 
                    new MessageContent<string>(message.MessageId, x),

                Dictionary<string, object> x => 
                    new MessageContent<Dictionary<string, object>>(message.MessageId, x),

                _ => 
                    throw new Exception("Uh oh")
            };

            return new ResponseMessage( message.MessageId, messageContent, requestMessage.Topics, "" );
        }

        public async Task CloseSession( RequestProviderSession session )
        {
            await _requestApi.CloseSessionAsync( session.Id );
        }
    }
}
