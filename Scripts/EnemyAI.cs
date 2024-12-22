using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 3.5f;
    public float detectionRange = 10f;
    public float damageRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 2.0f;

    private Transform currentTarget;
    private float nextAttackTime = 0f;

    void Start(){
        currentTarget = pointA;
    }

    void Update(){
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange){
            ChasePlayer();
        }
        else{
            Patrol();
        }

        if (distanceToPlayer <= damageRange && Time.time >= nextAttackTime){
            DamagePlayer();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Patrol(){
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f){
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }

    void ChasePlayer(){
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void DamagePlayer(){
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null){
            playerHealth.TakeDamage(damage);
            Debug.Log("Player damaged by enemy!");
        }
        else{
            Debug.LogError("Player does not have a PlayerHealth component attached!");
        }
    }
}
