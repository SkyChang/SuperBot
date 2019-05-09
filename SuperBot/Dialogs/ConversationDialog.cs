// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.3.0

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace SuperBot.Dialogs
{
    public class ConversationDialog : ComponentDialog
    {
        public ConversationDialog()
            : base(nameof(ConversationDialog))
        {
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                Conversation
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> Conversation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var result = stepContext.Options as string;
            if (string.IsNullOrEmpty(result))
            {
                await stepContext.Context.SendActivityAsync(MessageFactory.Text("我看不懂啦!"));
                return await stepContext.EndDialogAsync(null, cancellationToken);

            }

            result = result.Replace("你", "");
            result = result.Replace("妳", "");
            result = result.Replace("我", "");
            result = result.Replace("嗎", "");
            result = result.Replace("?", "!");

            await stepContext.Context.SendActivityAsync(MessageFactory.Text(result));

            return await stepContext.EndDialogAsync(null, cancellationToken);
        }
    }
}
