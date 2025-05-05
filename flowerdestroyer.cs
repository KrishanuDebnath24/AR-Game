using UnityEngine;

public class FlowerCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Option A – use tag
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);          // remove the flower
        }

    }
}
