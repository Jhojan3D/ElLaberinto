using UnityEngine;
using Unity.Cinemachine;

public class PreferenciasController : MonoBehaviour
{
    public CinemachineInputAxisController cinemachineInputAxisController;

    public void MusicController(float volumen)
    {
        AudioManager.Instance.musicSource.volume = volumen;
    }
    public void SxfController (float volumen)
    {
        AudioManager.Instance.sfxSource.volume = volumen;
    }
    public void SxfUiController (float volumen)
    {
        AudioManager.Instance.sfxUiSource.volume = volumen;
    }
    public void SensibilidadController(float sensibilidad)
    {
        cinemachineInputAxisController.Controllers[0].Input.Gain = sensibilidad;
        cinemachineInputAxisController.Controllers[1].Input.Gain = -sensibilidad;
    }
}
