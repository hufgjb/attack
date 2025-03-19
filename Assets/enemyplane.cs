using UnityEngine;

public class enemyplane : MonoBehaviour
{
    public float moveSpeed = 3f; // 移動速度
    public int health = 3; // 生命值

    void Update()
    {
        // 讓敵機面向 -X 軸
        transform.rotation = Quaternion.Euler(90f, 180f, 0);

        // 向左移動
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // 超出屏幕後銷毀
        if (transform.position.y < -10f)
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