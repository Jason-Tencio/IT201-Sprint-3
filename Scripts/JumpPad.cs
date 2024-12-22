using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public float jumpAmount = 35f;

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null){
                playerRigidbody.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
                Debug.Log("Player launched by Jump Pad!");
            }
        }
    }
}
