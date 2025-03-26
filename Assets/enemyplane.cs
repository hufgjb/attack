using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public float moveSpeed = 3f; // 移動速度
    public int health = 3; // 生命值
    private Transform player; // 主角的 Transform

    void Start()
    {
        // 嘗試尋找 Player 物件
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // 計算朝向 Player 的方向向量
            Vector2 direction = (player.position - transform.position).normalized;

            // 讓敵機面向 Player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // 朝向 Player 移動
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }

        // 超出屏幕後銷毀
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject); // 銷毀子彈
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // 銷毀敵機
        }
    }
}