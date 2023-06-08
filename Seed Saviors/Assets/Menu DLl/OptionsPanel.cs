using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] Toggle muteToggle;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text bgmVolText;
    [SerializeField] TMP_Text sfxVolText;
    private void OnEnable()
    {
        muteToggle.isOn = audioManager.IsMute;
        bgmSlider.value = audioManager.BgmVolume;
        sfxSlider.value = audioManager.SfxVolume;
        SetBgmVolume(bgmSlider.value);
        SetSfxVolume(sfxSlider.value);
    }

    public void SetBgmVolume(float value)
    {
        bgmVolText.text = Mathf.RoundToInt(value * 100).ToString();
    }

    public void SetSfxVolume(float value)
    {
        sfxVolText.text = Mathf.RoundToInt(value * 100).ToString();
    }
}
