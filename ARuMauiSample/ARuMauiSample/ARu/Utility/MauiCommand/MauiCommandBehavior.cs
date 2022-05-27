// ----------------------------------------------------------------------------
// using
// ----------------------------------------------------------------------------
using ARu.Utility.Binding;
using System.Reflection;
using System.Windows.Input;

// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Utility.MauiCommand;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// イベント引数取得用ビヘイビア
/// </summary>
public class MauiCommandBehavior : MauiBindingBehavior<VisualElement>
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------
    
    /// <summary>
    /// イベント名
    /// </summary>
    private string _eventName;

    /// <summary>
    /// デリゲート
    /// </summary>
    private Delegate _handler;

    /// <summary>
    /// イベント情報
    /// </summary>
    private EventInfo _oldEvent;

    // ----------------------------------------------------------------------------
    // property
    // ----------------------------------------------------------------------------
    
    /// <summary>
    /// イベント名
    /// </summary>
    public string EventName
    {
        get { return _eventName; }
        set { _eventName = value; }
    }

    /// <summary>
    /// コマンド
    /// </summary>
    public static readonly BindableProperty CommandProperty = BindableProperty.Create
        (
        nameof(Command),
        typeof(ICommand),
        typeof(MauiCommandBehavior),
        null
        );
    public ICommand Command
    {
        get
        {
            return (ICommand)GetValue(CommandProperty);
        }
        set
        {
            SetValue(CommandProperty, value);
        }
    }

    /// <summary>
    /// コマンドパラメータ
    /// </summary>
    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create
        (
        nameof(CommandParameter),
        typeof(object),
        typeof(MauiCommandBehavior),
        null
        );
    public object CommandParameter
    {
        get
        {
            return (object)GetValue(CommandParameterProperty);
        }
        set
        {
            SetValue(CommandParameterProperty, value);
        }
    }

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// イベント登録
    /// </summary>
    /// <param name="bindableObject"></param>
    protected override void OnAttachedTo(VisualElement bindableObject)
    {
        base.OnAttachedTo(bindableObject);
        
        // 既にイベントが登録されているならイベントハンドラを削除する
        if (_oldEvent != null)
        {
            _oldEvent.RemoveEventHandler(this.AssociatedObject, _handler);
        }
        
        // イベント名がnullか空文字でなければ新規にイベントを登録する
        if (string.IsNullOrEmpty(_eventName) == false)
        {
            // イベント取得
            EventInfo ei = this.AssociatedObject.GetType().GetEvent(_eventName);

            // 正規イベントかチェック
            if (ei != null)
            {
                MethodInfo mi = this.GetType().GetMethod("ExecuteCommand", BindingFlags.Instance | BindingFlags.NonPublic);
                _handler = Delegate.CreateDelegate(ei.EventHandlerType, this, mi);
                ei.AddEventHandler(this.AssociatedObject, _handler);
                _oldEvent = ei;
            }
            else
            {
                // NOP
            }
        }
    }

    /// <summary>
    /// イベント解除
    /// </summary>
    /// <param name="bindableObject"></param>
    protected override void OnDetachingFrom(VisualElement bindableObject)
    {
        if ((_oldEvent != null)
        && (_handler != null))
        {
            _oldEvent.RemoveEventHandler(this.AssociatedObject, _handler);
        }

        base.OnDetachingFrom(bindableObject);
    }

    /// <summary>
    /// コマンド実行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ExecuteCommand(object sender, EventArgs e)
    {
        // コマンドが登録されていればコマンド実行
        if (this.Command != null)
        {
            MauiCommandEventArgs mauiCommandEventArgs = new MauiCommandEventArgs(sender, e, CommandParameter);
            if (this.Command.CanExecute(mauiCommandEventArgs))
            {
                this.Command.Execute(mauiCommandEventArgs);
            }
        }
    }
}
