using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarDeEscena : MonoBehaviour
{
    public void CambiarScena(string nuevaEscena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nuevaEscena);
    }
}
