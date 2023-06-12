using UnityEngine;
using UnityEngine.UI;

public class SoundButtonManager : MonoBehaviour
{

    [SerializeField] private Image soundOnIcon;
    [SerializeField] private Image soundOffIcon;

    private bool _muted;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = _muted;
    }

    public void OnButtonPress()
    {
        if (!_muted) {
            _muted = true;
            AudioListener.pause = true;
        }
        else
        {
            _muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (!_muted)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        _muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", _muted ? 1 : 0);
    }
}
