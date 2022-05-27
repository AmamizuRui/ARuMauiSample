// ----------------------------------------------------------------------------
// namespace
// ----------------------------------------------------------------------------
namespace ARu.Control.ChangeTheme;

// ----------------------------------------------------------------------------
// class
// ----------------------------------------------------------------------------

/// <summary>
/// �e�[�}�ύX�s�b�J�[
/// </summary>
public partial class ChangeThemePicker : ContentView, IDisposable
{
    // ----------------------------------------------------------------------------
    // field
    // ----------------------------------------------------------------------------

    /// <summary>
    /// �e�[�}���X�g
    /// </summary>
    private List<ChangeThemeItem> _changeThemeItems;

    /// <summary>
    /// ���C�g�e�[�}
    /// </summary>
    private ChangeThemeItem _lightTheme;

    /// <summary>
    /// �_�[�N�e�[�}
    /// </summary>
    private ChangeThemeItem _darkTheme;

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
    public ChangeThemePicker()
	{
		InitializeComponent();

        // Picker�R���g���[��������
        _lightTheme = new ChangeThemeItem(ChangeTheme.THEME_NAME_LIGHT, AppTheme.Light);
        _darkTheme = new ChangeThemeItem(ChangeTheme.THEME_NAME_DARK, AppTheme.Dark);

        _changeThemeItems = new List<ChangeThemeItem>();
        _changeThemeItems.Add(_lightTheme);
        _changeThemeItems.Add(_darkTheme);

        _themePicker.ItemsSource = ChangeThemeItems;
        _themePicker.ItemDisplayBinding = new Binding(nameof(ChangeThemeItem.DisplayName));

        // �I����ԏ�����
        switch (Application.Current.UserAppTheme)
        {
            case AppTheme.Light:
                _themePicker.SelectedItem = _lightTheme;
                break;
            case AppTheme.Dark:
                _themePicker.SelectedItem = _darkTheme;
                break;
            default:
                _themePicker.SelectedItem = _lightTheme;
                break;
        }

        // �e�[�}�ύX�C�x���g�o�^
        _themePicker.SelectedIndexChanged += OnSelectedIndexChanged;
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
                // �e�[�}�ύX�C�x���g����
                _themePicker.SelectedIndexChanged -= OnSelectedIndexChanged;
            }

            // �A���}�l�[�W�h ���\�[�X (�A���}�l�[�W�h �I�u�W�F�N�g) ��������A�t�@�C�i���C�U�[���I�[�o�[���C�h���܂�
            // �傫�ȃt�B�[���h�� null �ɐݒ肵�܂�
            _disposedValue = true;
        }
    }

    /// <summary>
    /// �f�X�g���N�^
    /// </summary>
    ~ChangeThemePicker()
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
    /// �e�[�}���X�g
    /// </summary>
    public List<ChangeThemeItem> ChangeThemeItems
    {
        get { return _changeThemeItems; }
    }

    // ----------------------------------------------------------------------------
    // method
    // ----------------------------------------------------------------------------

    /// <summary>
    /// �e�[�}�ύX�C�x���g
    /// </summary>
    /// <param name="sender">�C�x���g�𔭐��������R���g���[��</param>
    /// <param name="e">�C�x���g����</param>
    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = sender as Picker;
        if (picker == null)
        {
            return;
        }

        ChangeThemeItem item = picker.SelectedItem as ChangeThemeItem;
        if (item == null)
        {
            return;
        }

        ChangeTheme.SetTheme(item.Theme);
    }
}