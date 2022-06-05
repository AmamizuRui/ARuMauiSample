// ----------------------------------------------------------------------------
// using
// ----------------------------------------------------------------------------
using Android.App;
using Android.Runtime;

// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARuMauiSample;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// MainApplication
/// </summary>
[Application]
public class MainApplication : MauiApplication
{
    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="handle"></param>
	/// <param name="ownership"></param>
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// MauiApp生成
    /// </summary>
    /// <returns></returns>
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
