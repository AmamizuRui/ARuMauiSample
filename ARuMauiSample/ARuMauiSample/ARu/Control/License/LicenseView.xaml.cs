// ----------------------------------------------------------------------------
// using
// ----------------------------------------------------------------------------
using System.Collections;

// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.License;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// ライセンス情報一覧
/// </summary>
public partial class LicenseView : ContentView, IDisposable
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

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
    public LicenseView()
	{
		InitializeComponent();
        _disposedValue = false;

        // アイテム選択イベント登録
        _licenseListView.ItemSelected += OnItemSelected;
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
            }

            // アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
            // 大きなフィールドを null に設定します
            _licenseListView.ItemSelected -= OnItemSelected;
            _disposedValue = true;
        }
    }

    /// <summary>
    /// デストラクタ
    /// </summary>
    ~LicenseView()
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
    /// ライセンス情報リスト
    /// </summary>
    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(LicenseView), null);

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// アイテム登録イベント
    /// </summary>
    /// <param name="sender">ListView</param>
    /// <param name="e">Args</param>
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        ListView listView = sender as ListView;
        if(sender == null)
        {
            return;
        }

        LicenseItem licenseItem = listView.SelectedItem as LicenseItem;
        if(licenseItem == null)
        {
            return;
        }

        // 選択したライセンス情報を登録
        LicenseManager.Instance.SelectedLicense = licenseItem;

        // ライセンス詳細ページへ遷移
        await Shell.Current.GoToAsync($"licenseDetailPage");

        // 選択状態解除
        listView.SelectedItem = null;
    }
}