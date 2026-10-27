using UnityEngine;

public class SonidoUI : MonoBehaviour
{
    public void PlaySfxUi(AudioClip audioClip)
    {
        AudioManager.Instance.PlaySfxUi(audioClip);
    }
}
