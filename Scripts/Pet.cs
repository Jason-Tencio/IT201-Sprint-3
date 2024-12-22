using UnityEngine;

public class Pet : MonoBehaviour
{
    public Transform target;
    public float speed = 3.0f;
    public float stoppingDistance = 9.0f;
    public float healingRange = 5.0f;
    public int healingAmount = 1;
    public float healingInterval = 1.0f;
    public LayerMask obstacleLayers;

    private float nextHealTime = 0f;

    void Update(){
        transform.LookAt(target);

        RaycastHit hit;
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        if (Physics.Raycast(transform.position, direction, out hit, distance, obstacleLayers)){
            Debug.Log("Obstacle detected: " + hit.collider.name);
            return;
        }

        if (distance > stoppingDistance){
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (distance <= healingRange && Time.time >= nextHealTime){
            HealPlayer();
            nextHealTime = Time.time + healingInterval;
        }
    }

    void HealPlayer(){
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healingAmount);
            Debug.Log("Pet healed the player by " + healingAmount);
        }
    }
}
