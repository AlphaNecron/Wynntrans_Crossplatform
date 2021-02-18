using System.Threading.Tasks;
using Avalonia;
using Avalonia.Input.Platform;

namespace Wynntrans_CrossAva.Core
{
    public static class Clipboard
    {
        public static async Task SetText(string text)
        {
            await ((IClipboard)AvaloniaLocator.Current.GetService(typeof(IClipboard)))
                .SetTextAsync(text);
        }
    }
}