// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.ChangeTheme;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// テーマ変更ピッカー
/// </summary>
public partial class ChangeThemePicker : ContentView, IDisposable
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

    /// <summary>
    /// テーマリスト
    /// </summary>
    private List<ChangeThemeItem> _changeThemeItems;

    /// <summary>
    /// ライトテーマ
    /// </summary>
    private ChangeThemeItem _lightTheme;

    /// <summary>
    /// ダークテーマ
    /// </summary>
    private ChangeThemeItem _darkTheme;

    /// <summary>
    /// Disposeしたか
    /// </summary>
    private bool _disposedValue;

    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ChangeThemePicker()
	{
		InitializeComponent();

        // Pickerコントロール初期化
        _lightTheme = new ChangeThemeItem(ChangeTheme.THEME_NAME_LIGHT, AppTheme.Light);
        _darkTheme = new ChangeThemeItem(ChangeTheme.THEME_NAME_DARK, AppTheme.Dark);

        _changeThemeItems = new List<ChangeThemeItem>();
        _changeThemeItems.Add(_lightTheme);
        _changeThemeItems.Add(_darkTheme);

        _themePicker.ItemsSource = ChangeThemeItems;
        _themePicker.ItemDisplayBinding = new Binding(nameof(ChangeThemeItem.DisplayName));

        // 選択状態初期化
        switch (Application.Current.UserAppTheme)
        {
            case AppTheme.Light:
                _themePicker.SelectedItem = _lightTheme;
                break;
            case AppTheme.Dark:
                _themePicker.SelectedItem = _darkTheme;
                break;
            default:
                _themePicker.SelectedItem = _lightTheme;
                break;
        }

        // テーマ変更イベント登録
        _themePicker.SelectedIndexChanged += OnSelectedIndexChanged;
    }

    // ----------------------------------------------------------------------------
    // finalizer
    // ----------------------------------------------------------------------------

    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing">true：Dispose呼び出し, false：デストラクタ呼び出し</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // マネージド状態を破棄します (マネージド オブジェクト)
                // テーマ変更イベント解除
                _themePicker.SelectedIndexChanged -= OnSelectedIndexChanged;
            }

            // アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
            // 大きなフィールドを null に設定します
            _disposedValue = true;
        }
    }

    /// <summary>
    /// デストラクタ
    /// </summary>
    ~ChangeThemePicker()
    {
        // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        Dispose(disposing: false);
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    // ----------------------------------------------------------------------------
    // property
    // ----------------------------------------------------------------------------

    /// <summary>
    /// テーマリスト
    /// </summary>
    public List<ChangeThemeItem> ChangeThemeItems
    {
        get { return _changeThemeItems; }
    }

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// テーマ変更イベント
    /// </summary>
    /// <param name="sender">イベントを発生させたコントロール</param>
    /// <param name="e">イベント引数</param>
    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = sender as Picker;
        if (picker == null)
        {
            return;
        }

        ChangeThemeItem item = picker.SelectedItem as ChangeThemeItem;
        if (item == null)
        {
            return;
        }

        ChangeTheme.SetTheme(item.Theme);
    }
}