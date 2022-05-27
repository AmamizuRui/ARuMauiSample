// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Utility.MauiCommand;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// Command用イベント引数クラス
/// </summary>
public class MauiCommandEventArgs : IDisposable
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
    /// <param name="sender">イベントを発生させたオブジェクト</param>
    /// <param name="e">イベント引数</param>
    /// <param name="commandParameter">コマンド引数</param>
    public MauiCommandEventArgs(object sender, EventArgs e, object commandParameter)
    {
        _disposedValue = false;

        Sender = sender;
        Args = e;
        CommandParameter = commandParameter;
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
                Sender = null;
                Args = null;
                CommandParameter = null;
            }

            // アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
            // 大きなフィールドを null に設定します
            _disposedValue = true;
        }
    }

    /// <summary>
    /// デストラクタ
    /// </summary>
    ~MauiCommandEventArgs()
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
    /// イベントを発生させたオブジェクト
    /// </summary>
    public object Sender { get; set; }

    /// <summary>
    /// イベント引数
    /// </summary>
    public EventArgs Args { get; set; }

    /// <summary>
    /// コマンド引数
    /// </summary>
    public object CommandParameter { get; set; }
}
