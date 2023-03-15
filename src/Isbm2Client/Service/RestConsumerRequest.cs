﻿using Isbm2Client.Interface;
using Isbm2Client.Model;
using RestModel = Isbm2RestClient.Model;
using Isbm2Client.Extensions;
using Isbm2RestClient.Api;

namespace Isbm2Client.Service;

public class RestConsumerRequest : IConsumerRequest
{
    private readonly IConsumerRequestServiceApi _requestApi;

    public RestConsumerRequest( IConsumerRequestServiceApi requestApi )
    {
        _requestApi = requestApi;
    }

    public async Task<RequestConsumerSession> OpenSession( string channelUri )
    {
        var sessionParams = new RestModel.Session()
        {
            SessionType = RestModel.SessionType.RequestConsumer
        };

        var session = await _requestApi.OpenConsumerRequestSessionAsync( channelUri, sessionParams );

        if ( session is null ) throw new Exception( "Uh oh" );

        return new RequestConsumerSession( session.SessionId, sessionParams.ListenerUrl );
    }

    public async Task<RequestConsumerSession> OpenSession(string channelUri, string listenerUri)
    {
        var sessionParams = new RestModel.Session()
        {
            SessionType = RestModel.SessionType.RequestConsumer,
            ListenerUrl = listenerUri
        };

        var session = await _requestApi.OpenConsumerRequestSessionAsync(channelUri, sessionParams);

        if ( session is null ) throw new Exception("Uh oh");

        return new RequestConsumerSession(session.SessionId, sessionParams.ListenerUrl);
    }

    public Task<RequestMessage> PostRequest<T>( string sessionId, T content, string topic, string? expiry = null ) where T : notnull
    {
        var topics = new[] { topic };

        return PostRequest( sessionId, content, topics, expiry );
    }

    public async Task<RequestMessage> PostRequest<T>( string sessionId, T content, IEnumerable<string> topics, string? expiry = null ) where T : notnull
    {
        var messageContent = Model.MessageContent.From(content);

        var restMessage = new RestModel.Message
        ( 
            messageContent: messageContent.ToRestMessageContent(), 
            topics: topics.ToList(),
            expiry: expiry
        );

        var message = await _requestApi.PostRequestAsync( sessionId, restMessage );

        return new RequestMessage( message.MessageId, messageContent, topics.ToArray(), "" );
    }

    public async Task ExpireRequest(string sessionId, string messageId)
    {
        await _requestApi.ExpireRequestAsync( sessionId, messageId );
    }

    public async Task<ResponseMessage> ReadResponse(string sessionId, string requestMessageId)
    {
        var response = await _requestApi.ReadResponseAsync( sessionId, requestMessageId );
        var content = response.MessageContent.Content.ActualInstance;
        var messageContent = Model.MessageContent.From( content );

        return new ResponseMessage( response.MessageId, messageContent, response.RequestMessageId ?? requestMessageId );
    }

    public async Task RemoveResponse( string sessionId, string requestId )
    {
        await _requestApi.RemoveResponseAsync( sessionId, requestId );
    }

    public async Task CloseSession(string sessionId)
    {
        await _requestApi.CloseSessionAsync(sessionId);
    }
}
