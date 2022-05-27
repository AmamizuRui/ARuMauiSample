// ----------------------------------------------------------------------------
// using
// ----------------------------------------------------------------------------
using System.ComponentModel;
using System.Runtime.CompilerServices;

// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Utility.Binding;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// MAUI用バインドクラス
/// </summary>
public class MauiBinding : INotifyPropertyChanged
{
    // ----------------------------------------------------------------------------
    // event
    // ----------------------------------------------------------------------------

    /// <summary>
    /// プロパティ変更通知用イベントハンドラ
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// プロパティ設定処理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sourceValue">設定前データ</param>
    /// <param name="setValue">設定データ</param>
    /// <param name="propertyName">プロパティ名</param>
    protected void SetPropertyValue<T>(ref T sourceValue, T setValue, [CallerMemberName] string propertyName = null)
    {
        // 設定値が変更されていれば、プロパティの変更を通知する
        if (Equals(sourceValue, setValue) == false)
        {
            sourceValue = setValue;
            OnPropertyChanged(propertyName);
        }
    }

    /// <summary>
    /// プロパティ変更通知
    /// </summary>
    /// <param name="propertyName">プロパティ名</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;

        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
