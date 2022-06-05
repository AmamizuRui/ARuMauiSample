// ----------------------------------------------------------------------------
// using
// ----------------------------------------------------------------------------
using Android.App;
using Android.Content.PM;
using Android.OS;

// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARuMauiSample;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// MainActivity
/// </summary>
[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// Activity生成
    /// </summary>
    /// <param name="savedInstanceState"></param>
    protected override void OnCreate(Bundle savedInstanceState)
    {
        SetFont("fa-solid-900.ttf");
        base.OnCreate(savedInstanceState);
    }

    /// <summary>
    /// フォント設定
    /// </summary>
    /// <param name="fontFileName">フォントファイル名</param>
    private void SetFont(string fontFileName)
    {
        string fontPath = Path.Combine(CacheDir.AbsolutePath, fontFileName);
        using (Stream asset = Assets.Open(fontFileName))
        {
            using (FileStream dest = File.Open(fontPath, FileMode.Create))
            {
                asset.CopyTo(dest);
            }
        }
    }
}
