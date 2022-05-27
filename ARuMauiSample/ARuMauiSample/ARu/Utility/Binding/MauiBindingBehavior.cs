// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Utility.Binding;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// ビヘイビアベースクラス
/// </summary>
public class MauiBindingBehavior<T> : Behavior<T> where T : BindableObject
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

    /// <summary>
    /// バインドするオブジェクト
    /// </summary>
    private T _associatedObject;

    // ----------------------------------------------------------------------------
    // property
    // ----------------------------------------------------------------------------

    /// <summary>
    /// バインドするオブジェクトプロパティ
    /// </summary>
    protected T AssociatedObject
    {
        get { return _associatedObject; }
        set { _associatedObject = value; }
    }

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// アタッチ
    /// </summary>
    /// <param name="bindableObject">バインドするオブジェクト</param>
    protected override void OnAttachedTo(T bindableObject)
    {
        base.OnAttachedTo(bindableObject);

        _associatedObject = bindableObject;
        if (_associatedObject.BindingContext != null)
        {
            this.BindingContext = _associatedObject.BindingContext;
        }

        _associatedObject.BindingContextChanged += OnBindingContextChanged;
    }

    /// <summary>
    /// デタッチ
    /// </summary>
    /// <param name="bindableObject">バインド解除するオブジェクト</param>
    protected override void OnDetachingFrom(T bindableObject)
    {
        bindableObject.BindingContextChanged -= OnBindingContextChanged;
    }

    /// <summary>
    /// バインド変更イベント
    /// </summary>
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        this.BindingContext = _associatedObject.BindingContext;
    }

    /// <summary>
    /// バインド変更イベント
    /// </summary>
    /// <param name="sender">イベントを発生させたオブジェクト</param>
    /// <param name="e">イベント引数</param>
    private void OnBindingContextChanged(object sender, EventArgs e)
    {
        this.OnBindingContextChanged();
    }
}
