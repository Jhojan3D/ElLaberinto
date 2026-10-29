using UnityEngine;

public class Victoria : MonoBehaviour
{
    public GameObject panelVictoria;
    public AudioClip sondVictotia;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            panelVictoria.SetActive(true);
            AudioManager.Instance.PlaySfx(sondVictotia);
        }
    }
}
