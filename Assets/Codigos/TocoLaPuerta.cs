using UnityEngine;
using UnityEngine.SceneManagement;

public class TocoLaPuerta : MonoBehaviour
{
    [SerializeField] private string reiniciarEscena;
    [SerializeField] private AudioClip sonidoPortal;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySfx(sonidoPortal);
            SceneManager.LoadScene(reiniciarEscena);
        }
    }



}
