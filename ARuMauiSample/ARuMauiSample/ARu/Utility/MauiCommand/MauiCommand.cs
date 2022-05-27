// ----------------------------------------------------------------------------
// using
// ----------------------------------------------------------------------------
using System.Windows.Input;

// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Utility.MauiCommand;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// MAUI用コマンドクラス
/// </summary>
public class MauiCommand<T> : ICommand
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

    /// <summary>
    /// 実行処理
    /// </summary>
    private Action<T> _execute;

    /// <summary>
    /// 実行可能状態判定処理
    /// </summary>
    private Func<T, bool> _canExecute;

    /// <summary>
    /// 値型判定結果
    /// </summary>
    private bool _isValueType;

    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public MauiCommand()
    {
        _isValueType = typeof(T).IsValueType;
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="execute">実行関数</param>
    /// <remarks>必ず実行可能なコマンドの場合、こちらのコンストラクタを使用する</remarks>
    public MauiCommand(Action<T> execute) : this(execute, o => true)
    {

    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="execute">実行関数</param>
    /// <param name="canExecute">実行可能状態判定関数</param>
    public MauiCommand(Action<T> execute, Func<T, bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    // ----------------------------------------------------------------------------
    // event
    // ----------------------------------------------------------------------------

    /// <summary>
    /// 実行可能状態更新イベント
    /// </summary>
    public event EventHandler CanExecuteChanged;

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// 実行可能状態更新
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 実行可能状態取得
    /// </summary>
    /// <param name="parameter">引数</param>
    /// <returns>実行可能状態</returns>
    bool ICommand.CanExecute(object parameter)
    {
        if (_canExecute == null)
        {
            return false;
        }

        return _canExecute(Cast(parameter));
    }

    /// <summary>
    /// 実行
    /// </summary>
    /// <param name="parameter">引数</param>
    void ICommand.Execute(object parameter)
    {
        if (_execute == null)
        {
            return;
        }

        _execute(Cast(parameter));
    }

    /// <summary>
    /// 型変換
    /// </summary>
    /// <param name="parameter">引数</param>
    /// <returns>値</returns>
    private T Cast(object parameter)
    {
        if ((parameter == null)
        && (_isValueType == true))
        {
            return default(T);
        }

        return (T)parameter;
    }
}
