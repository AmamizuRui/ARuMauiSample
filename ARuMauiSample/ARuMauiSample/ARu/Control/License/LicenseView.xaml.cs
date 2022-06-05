// ----------------------------------------------------------------------------
// using
// ----------------------------------------------------------------------------
using System.Collections;

// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.License;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// ���C�Z���X���ꗗ
/// </summary>
public partial class LicenseView : ContentView, IDisposable
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

    /// <summary>
    /// Dispose������
    /// </summary>
    private bool _disposedValue;

    // ----------------------------------------------------------------------------
    // constructor
    // ----------------------------------------------------------------------------

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public LicenseView()
	{
		InitializeComponent();
        _disposedValue = false;

        // �A�C�e���I���C�x���g�o�^
        _licenseListView.ItemSelected += OnItemSelected;
    }

    // ----------------------------------------------------------------------------
    // finalizer
    // ----------------------------------------------------------------------------

    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing">true�FDispose�Ăяo��, false�F�f�X�g���N�^�Ăяo��</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // �}�l�[�W�h��Ԃ�j�����܂� (�}�l�[�W�h �I�u�W�F�N�g)
            }

            // �A���}�l�[�W�h ���\�[�X (�A���}�l�[�W�h �I�u�W�F�N�g) ��������A�t�@�C�i���C�U�[���I�[�o�[���C�h���܂�
            // �傫�ȃt�B�[���h�� null �ɐݒ肵�܂�
            _licenseListView.ItemSelected -= OnItemSelected;
            _disposedValue = true;
        }
    }

    /// <summary>
    /// �f�X�g���N�^
    /// </summary>
    ~LicenseView()
    {
        // ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h�� 'Dispose(bool disposing)' ���\�b�h�ɋL�q���܂�
        Dispose(disposing: false);
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        // ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h�� 'Dispose(bool disposing)' ���\�b�h�ɋL�q���܂�
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    // ----------------------------------------------------------------------------
    // property
    // ----------------------------------------------------------------------------

    /// <summary>
    /// ���C�Z���X��񃊃X�g
    /// </summary>
    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(LicenseView), null);

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// �A�C�e���o�^�C�x���g
    /// </summary>
    /// <param name="sender">ListView</param>
    /// <param name="e">Args</param>
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        ListView listView = sender as ListView;
        if(sender == null)
        {
            return;
        }

        LicenseItem licenseItem = listView.SelectedItem as LicenseItem;
        if(licenseItem == null)
        {
            return;
        }

        // �I���������C�Z���X����o�^
        LicenseManager.Instance.SelectedLicense = licenseItem;

        // ���C�Z���X�ڍ׃y�[�W�֑J��
        await Shell.Current.GoToAsync($"licenseDetailPage");

        // �I����ԉ���
        listView.SelectedItem = null;
    }
}