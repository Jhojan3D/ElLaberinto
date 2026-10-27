using UnityEngine;
using UnityEngine.UI;

public class GuardarPreferencias : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider sfxUiSlider;
    public Slider sensibilidadSlider;

    private void Awake()
    {
        ChequearPreferencias();
    }
    private void Start()
    {
        CargarPreferencias();
    }
    private void ChequearPreferencias()
    {
        if(!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 0.8f);
        }
        if (!PlayerPrefs.HasKey("Sfx"))
        {
            PlayerPrefs.SetFloat("Sfx", 0.8f);
        }
        if (!PlayerPrefs.HasKey("SfxUi"))
        {
            PlayerPrefs.SetFloat("SfxUi", 0.8f);
        }
        if (!PlayerPrefs.HasKey("Sensibilidad"))
        {
            PlayerPrefs.SetFloat("Sensibilidad", 16f);
        }
    }
    private void CargarPreferencias()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        sfxSlider.value = PlayerPrefs.GetFloat("Sfx");
        sfxUiSlider.value = PlayerPrefs.GetFloat("SfxUi");
        sensibilidadSlider.value = PlayerPrefs.GetFloat("Sensibilidad");

    }
    public void MusicGuardar()
    {
        if(PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", musicSlider.value);
        }
        Debug.Log("Music Guardada" + PlayerPrefs.GetFloat("Music"));
    }
    public void SfxGuardar()
    {
        if (PlayerPrefs.HasKey("Sfx"))
        {
            PlayerPrefs.SetFloat("Sfx", sfxSlider.value);
        }
        Debug.Log("Sfx guardada" + PlayerPrefs.GetFloat("Sfx"));
    }
    public void SfxUiGuardar()
    {
        if (PlayerPrefs.HasKey("SfxUi"))
        {
            PlayerPrefs.SetFloat("SfxUi", sfxUiSlider.value);
        }
        Debug.Log("SfxUi Guardada" + PlayerPrefs.GetFloat("SfxUi"));
    }
    public void SensibilidadGuardar()
    {
        if (PlayerPrefs.HasKey("Sensibilidad"))
        {
            PlayerPrefs.SetFloat("Sensibilidad", sensibilidadSlider.value);
        }
        Debug.Log("Sensibilidad guardada" + PlayerPrefs.GetFloat("Sensibilidad"));
    }
}
