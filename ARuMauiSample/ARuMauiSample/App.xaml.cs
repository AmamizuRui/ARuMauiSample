using ARu.Control.ChangeTheme;

namespace ARuMauiSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		ChangeTheme.InitializeTheme();
		MainPage = new AppShell();
	}
}
