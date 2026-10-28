using UnityEngine;

public class SonidoAmbiente : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoAmbiente;

    private void Start()
    {
        PlaySonidoAmbiente();
    }

    private void PlaySonidoAmbiente()
    {
        AudioManager.Instance.PlayMusic(sonidoAmbiente);
    }
}
