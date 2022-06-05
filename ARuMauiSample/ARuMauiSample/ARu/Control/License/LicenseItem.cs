// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.License;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// ライセンス情報
/// </summary>
public class LicenseItem
{
    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="licenseName">ライセンス名</param>
    /// <param name="licenseDetail">ライセンス詳細</param>
    public LicenseItem(string licenseName, string licenseDetail)
    {
        LicenseName = licenseName;
        LicenseDetail = licenseDetail;
    }

    // ----------------------------------------------------------------------------
    // property
    // ----------------------------------------------------------------------------

    /// <summary>
    /// ライセンス名
    /// </summary>
    public string LicenseName { get; set; }

    /// <summary>
    /// ライセンス詳細
    /// </summary>
    public string LicenseDetail { get; set; }
}
