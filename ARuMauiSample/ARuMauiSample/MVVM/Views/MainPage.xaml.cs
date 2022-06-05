// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARuMauiSample;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// メインページ
/// </summary>
public partial class MainPage : ContentPage
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

	/// <summary>
	/// クリック回数
	/// </summary>
    private int _clickCount = 0;

    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// コンストラクタ
    /// </summary>
	public MainPage()
	{
		InitializeComponent();
	}

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// ボタンクリックイベント
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">Args</param>
    private void OnCounterClicked(object sender, EventArgs e)
	{
        _clickCount++;

		if (_clickCount == 1)
			CounterBtn.Text = $"Clicked {_clickCount} time";
		else
			CounterBtn.Text = $"Clicked {_clickCount} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

