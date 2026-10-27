using UnityEngine;

public class Pausa : MonoBehaviour
{
    public void IsPausa( bool isPaused)
    {
        isPaused = !isPaused;
        Time.timeScale = !isPaused ? 0f : 1f;
    }
}
