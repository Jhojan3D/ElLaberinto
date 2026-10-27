using UnityEngine;
using UnityEngine.SceneManagement;

public class TocoLaPuerta : MonoBehaviour
{
    [SerializeField] private string reiniciarEscena;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(reiniciarEscena);
        }
    }



}
