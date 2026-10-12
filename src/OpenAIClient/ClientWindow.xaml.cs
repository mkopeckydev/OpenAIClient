using OpenAIClient.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace OpenAIClient
{
    public partial class MainWindow : FluentWindow
    {
        public const string DefaultServerUrl = "http://127.0.0.1:1234/v1";
        public const string DefaultModelName = "qwen/qwen3.5-9b";
        public const string DefaultAuthenticationToken = "sk-lm-2cgsjsRb:LMELBTNL5A5PIUkveg5g";

        public MainWindow()
        {
            InitializeComponent();
        }

        public void AppendMessage(MessageAuthorEnum author, string message)
        {
            var paragraph = new Paragraph
            {
                Margin = new Thickness(0, 0, 0, 12),
                FontFamily = new FontFamily("Calibri"),
            };

            var authorRun = new Run(author switch
            {
                MessageAuthorEnum.User => "Ty: ",
                MessageAuthorEnum.AI => "AI: ",
                MessageAuthorEnum.Error => "Chyba: ",
                _ => string.Empty
            })
            {
                FontWeight = FontWeights.SemiBold,
                Foreground = author switch
                {
                    MessageAuthorEnum.User => Brushes.Green,
                    MessageAuthorEnum.AI => Brushes.Blue,
                    MessageAuthorEnum.Error => Brushes.Red,
                    _ => Brushes.Black
                }
            };

            paragraph.Inlines.Add(authorRun);
            paragraph.Inlines.Add(new Run(message));

            ConversationRichTextBox.Document.Blocks.Add(paragraph);
            ConversationRichTextBox.ScrollToEnd();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            await SendMessageAsync();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.None)
            {
                e.Handled = true;
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            var message = MessageTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(message) || !SendButton.IsEnabled)
            {
                return;
            }

            AppendMessage(MessageAuthorEnum.User, message);
            MessageTextBox.Clear();
            SendButton.IsEnabled = false;
            ProcessingStatusTextBlock.Text = "Čekám na zpracování zprávy...";
            ProcessingStatusTextBlock.Visibility = Visibility.Visible;

            try
            {
                var openAIManager = new OpenAIManager(
                    ServerUrlTextBox.Text.Trim(),
                    ModelNameTextBox.Text.Trim(),
                    AuthenticationTokenTextBox.Text.Trim());

                var response = await openAIManager.SendMessage(message);
                AppendMessage(MessageAuthorEnum.AI, response);
            }
            catch (Exception exception)
            {
                AppendMessage(MessageAuthorEnum.Error, exception.Message);
            }
            finally
            {
                SendButton.IsEnabled = true;
                ProcessingStatusTextBlock.Visibility = Visibility.Collapsed;
                MessageTextBox.Focus();
            }
        }
    }
}