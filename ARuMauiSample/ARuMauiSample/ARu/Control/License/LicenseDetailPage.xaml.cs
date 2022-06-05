// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.License;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// ���C�Z���X�ڍ׃y�[�W
/// </summary>
public partial class LicenseDetailPage : ContentPage
{
    // ----------------------------------------------------------------------------
    // const
    // ----------------------------------------------------------------------------

    /// <summary>
    /// �y�[�W��
    /// </summary>
    public const string PAGENAME = "licenseDetailPage";

    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public LicenseDetailPage()
	{
		InitializeComponent();

        // ���C�Z���X���\��
        _licenseNameLabel.Text = LicenseManager.Instance.SelectedLicense?.LicenseName;
        _licenseDetailLabel.Text = LicenseManager.Instance.SelectedLicense?.LicenseDetail;
    }
}