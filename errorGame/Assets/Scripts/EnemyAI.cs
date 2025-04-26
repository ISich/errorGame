using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float damage = 10f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;

    private Transform player;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            // Здесь будет урон
            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }
}
