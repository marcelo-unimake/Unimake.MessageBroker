﻿using Unimake.MessageBroker.Primitives.Model.Notifications;
using Unimake.MessageBroker.Services;
using Unimake.MessageBroker.Test.Abstractions;
using Xunit;
using Xunit.Abstractions;

namespace Unimake.MessageBroker.Test.BugFix
{
    public class Bug157182 : TestBase
    {
        #region Public Constructors

        public Bug157182(ITestOutputHelper output)
            : base(output)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [Fact]
        public async Task FixItAsync()
        {
            using var scope = await CreateAuthenticatedScopeAsync();

            var alertNotication = new AlertNotification
            {
                Testing = false,
                Text = "Mensagem de erro.",
                To = "5544991848774",
                Title = "UNINFE - Erro no envio documentos eletrônicos"
            };

            var messageService = new MessageService(Primitives.Enumerations.MessagingService.WhatsApp);
            await messageService.SendAlertAsync(alertNotication, scope);
        }

        #endregion Public Methods
    }
}