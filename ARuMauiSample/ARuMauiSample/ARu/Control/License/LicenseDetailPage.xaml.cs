// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.License;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// ライセンス詳細ページ
/// </summary>
public partial class LicenseDetailPage : ContentPage
{
    // ----------------------------------------------------------------------------
    // const
    // ----------------------------------------------------------------------------

    /// <summary>
    /// ページ名
    /// </summary>
    public const string PAGENAME = "licenseDetailPage";

    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public LicenseDetailPage()
	{
		InitializeComponent();

        // ライセンス情報表示
        _licenseNameLabel.Text = LicenseManager.Instance.SelectedLicense?.LicenseName;
        _licenseDetailLabel.Text = LicenseManager.Instance.SelectedLicense?.LicenseDetail;
    }
}