using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            PlayerEconomy playerEconomy = other.GetComponent<PlayerEconomy>();
            if (playerEconomy != null){
                playerEconomy.AddResources(value);
                Debug.Log("Player collected: " + value + " resources.");
            }

            Destroy(gameObject);
        }
    }
}

