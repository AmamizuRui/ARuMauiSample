// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARuMauiSample;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// MAUI
/// </summary>
public static class MauiProgram
{
    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// MAUIアプリケーション生成
    /// </summary>
    /// <returns>MAUIアプリケーション</returns>
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
            });

		return builder.Build();
	}
}
