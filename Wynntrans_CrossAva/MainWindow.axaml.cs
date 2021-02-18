using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input.Platform;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using TextCopy;
using Wynntrans_CrossAva.Core;

namespace Wynntrans_CrossAva
{
    public class MainWindow : Window
    {
        private Translator.Language _language = Translator.Language.Wynnic;
        private string _translatedText = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            GetControl<TextBox>("TbOutput").ContextMenu.FontFamily = FontFamily.Default;
            GetControl<TextBlock>("TextInfo").Text = $"Platform: {OS.GetOS().ToString()} | Made with ❤ by AlphaNecron";
        }

        private T GetControl<T>(string name) where T : class, IControl => this.FindControl<T>(name);

        private void Translate(object i, RoutedEventArgs _)
        {
            var input = GetControl<TextBox>("TbInput");
            var output = GetControl<TextBox>("TbOutput");
            if (string.IsNullOrEmpty(input.Text) || string.IsNullOrWhiteSpace(input.Text)) return;
            output.FontFamily = _language == Translator.Language.Wynnic
                ? FontFamily.Parse("Wynnic")
                : FontFamily.Default;
            output.Text = input.Text;
            _translatedText = Translator.StringConverter(input.Text, _language);
        }

        private void LanguageChanged(object i, RoutedEventArgs _)
        {
            var button = (ToggleButton) i;
            _language = button.IsChecked switch
            {
                true => Translator.Language.Gavellian,
                false => Translator.Language.Wynnic,
                null => _language
            };
            var output = GetControl<TextBox>("TbOutput");
            output.Text = string.Empty;
            output.FontFamily = _language == Translator.Language.Wynnic
                ? FontFamily.Parse("Wynnic") // The context menu is affected either...
                : FontFamily.Default;
            output.ContextMenu.FontFamily = FontFamily.Default;
            button.Content = _language.ToString();
        }

        private void CopyToClipboard(object i, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_translatedText) || string.IsNullOrWhiteSpace(_translatedText)) return;
            ClipboardService.SetText(_translatedText);
        }
    }
}