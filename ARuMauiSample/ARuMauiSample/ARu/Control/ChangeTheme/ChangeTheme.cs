﻿// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.ChangeTheme;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// テーマ変更静的クラス
/// </summary>
public static class ChangeTheme
{
    // ----------------------------------------------------------------------------
    // const
    // ----------------------------------------------------------------------------

    /// <summary>
    /// テーマ情報保存キー
    /// </summary>
    public const string KEY_THEME_NAME = "UseTheme";

    /// <summary>
    /// テーマ情報(テーマ未保存)
    /// </summary>
    public const string THEME_NAME_NONE = "None";

    /// <summary>
    /// テーマ情報(ライト)
    /// </summary>
    public const string THEME_NAME_LIGHT = "ライト";

    /// <summary>
    /// テーマ情報(ダーク)
    /// </summary>
    public const string THEME_NAME_DARK = "ダーク";

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// テーマ初期化
    /// </summary>
    public static void InitializeTheme()
    {
        string themeName = Preferences.Get(KEY_THEME_NAME, THEME_NAME_NONE);
        AppTheme appTheme = AppTheme.Unspecified;

        switch (themeName)
        {
            case THEME_NAME_NONE:
                appTheme = Application.Current.RequestedTheme;
                break;
            case THEME_NAME_LIGHT:
                appTheme = AppTheme.Light;
                break;
            case THEME_NAME_DARK:
                appTheme = AppTheme.Dark;
                break;
            default:
                appTheme = AppTheme.Light;
                break;
        }

        SetTheme(appTheme);
    }

    /// <summary>
    /// テーマ設定
    /// </summary>
    /// <param name="appTheme">設定するテーマ</param>
    public static void SetTheme(AppTheme appTheme)
    {
        string saveTheme = THEME_NAME_NONE;
        switch(appTheme)
        {
            case AppTheme.Light:
                saveTheme = THEME_NAME_LIGHT;
                break;
            case AppTheme.Dark:
                saveTheme = THEME_NAME_DARK;
                break;
            default:
                saveTheme = THEME_NAME_LIGHT;
                break;
        }

        Preferences.Set(KEY_THEME_NAME, saveTheme);
        Application.Current.UserAppTheme = appTheme;
    }
}
