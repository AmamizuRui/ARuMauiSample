// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.License;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// ライセンス情報管理
/// </summary>
public class LicenseManager
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

    /// <summary>
    /// シングルトン
    /// </summary>
    private static LicenseManager _instance;

    /// <summary>
    /// ライセンス情報リスト
    /// </summary>
    private List<LicenseItem> _licenseItems;

    /// <summary>
    /// 選択したライセンス情報
    /// </summary>
    private LicenseItem _selectedLicense;

    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private LicenseManager()
    {
        _licenseItems = new List<LicenseItem>();
        _selectedLicense = null;
    }

    // ----------------------------------------------------------------------------
    // property
    // ----------------------------------------------------------------------------

    /// <summary>
    /// インスタンスプロパティ
    /// </summary>
    public static LicenseManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new LicenseManager();
            }
            return _instance;
        }
    }

    /// <summary>
    /// ライセンス情報リストプロパティ
    /// </summary>
    public List<LicenseItem> LicenseItems
    {
        get { return _licenseItems; }
    }

    /// <summary>
    /// 選択したライセンス情報プロパティ
    /// </summary>
    public LicenseItem SelectedLicense
    {
        get { return _selectedLicense; }
        set { _selectedLicense = value; }
    }
}
