using UnityEngine;

public class Victoria : MonoBehaviour
{
    public GameObject panelVictoria;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            panelVictoria.SetActive(true);
        }
    }
}
