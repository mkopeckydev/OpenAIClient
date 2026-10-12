using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace OpenAIClient
{
    public class OpenAIManager
    {
        private static readonly TimeSpan ApiTimeout = TimeSpan.FromSeconds(300);
        private readonly ChatClient _chatClient;

        public OpenAIManager(string serverUrl, string modelName, string authenticationToken)
        {
            if (!Uri.TryCreate(serverUrl, UriKind.Absolute, out var endpoint))
            {
                throw new ArgumentException("URL serveru není platná.", nameof(serverUrl));
            }

            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentException("Název modelu nesmí být prázdný.", nameof(modelName));
            }

            if (string.IsNullOrWhiteSpace(authenticationToken))
            {
                throw new ArgumentException("Autentizační token nesmí být prázdný.", nameof(authenticationToken));
            }

            var options = new OpenAIClientOptions
            {
                Endpoint = endpoint,
                NetworkTimeout = ApiTimeout
            };

            _chatClient = new ChatClient(
                model: modelName,
                credential: new ApiKeyCredential(authenticationToken),
                options: options);
        }

        public async Task<string> SendMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Zpráva nesmí být prázdná.", nameof(message));
            }

            var response = await _chatClient.CompleteChatAsync(message);
            return response.Value.Content[0].Text;
        }
    }
}
