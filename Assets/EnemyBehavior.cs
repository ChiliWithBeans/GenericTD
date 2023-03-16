using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehavior : MonoBehaviour
{
    GameManager manager;
    public float health;
    public float speed;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Home")
        {
            manager.baseHealth -= 1;
            if (manager.baseHealth <= 0)
            {
                manager.gameOver();
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log(gameObject);
            health -= 1;
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                manager.score += 1;
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag == "Turret")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime / 10);
    }
}
