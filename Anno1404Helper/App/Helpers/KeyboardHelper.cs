using Android.Content;
using Android.Views.InputMethods;

namespace Anno1404Helper.App.Helpers;

public static class KeyboardHelper
{
    /// <summary>
    /// Force display of keyboard on the entry in parameters.
    /// </summary>
    /// <param name="entry">the entry which will receive the text from keyboard</param>
    public static void ForceDisplayKeyboard(Entry entry)
    {
        if(entry == null) return;
        if (entry.Handler == null) return;
#if ANDROID
        
        var platform = Platform.CurrentActivity;
        if(platform == null) return;
        InputMethodManager inputManager = (InputMethodManager)platform.GetSystemService(Context.InputMethodService);
        if (inputManager == null) return;
        inputManager.ShowSoftInput(entry.Handler.PlatformView as AndroidX.AppCompat.Widget.AppCompatEditText, Android.Views.InputMethods.ShowFlags.Forced);
#endif
    }
}