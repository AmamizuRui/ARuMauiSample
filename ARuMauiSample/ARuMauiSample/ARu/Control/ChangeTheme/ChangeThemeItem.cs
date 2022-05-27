// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.ChangeTheme;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// テーマアイテムクラス
/// </summary>
public class ChangeThemeItem
{
    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="displayName">Pickerに表示する項目名</param>
    /// <param name="theme">テーマ</param>
    public ChangeThemeItem(string displayName, AppTheme theme)
    {
        DisplayName = displayName;
        Theme = theme;
    }

    // ----------------------------------------------------------------------------
    // property
    // ----------------------------------------------------------------------------

    /// <summary>
    /// Pickerに表示する項目名
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// テーマ
    /// </summary>
    public AppTheme Theme { get; set; }
}
