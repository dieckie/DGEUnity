using UnityEngine;
using System.Collections;

namespace Enemys
{
    public abstract class Enemy : MonoBehaviour
    {

        public float speed = 1f;
        public float maxHealth = 10f;
        public float damage = 1f;


        internal GameObject player;
        internal Rigidbody2D rb;
        internal float direction = 1f;
        internal bool up = false;
        internal float health;
        internal float jump = 7f;

        // Use this for initialization
		internal void Start()
        {
            health = maxHealth;
            player = GameObject.FindGameObjectWithTag("Player");
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            Movement();
        }

        void Movement()
        {
            if (!up)
            {
                rb.velocity = new Vector2(speed * direction, 0f);


            }
        }

        private Collider2D lastCollider;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("ColUp"))
            {
                up = true;
                rb.velocity = new Vector2(0f, jump);
            }
            else if (col.CompareTag("ColSide"))
            {
                if (lastCollider != null)
                {
                    if (!lastCollider.Equals(col))
                    {
                        direction *= -1;
                        lastCollider = col;
                    }
                }
                else
                {
                    direction *= -1;
                    lastCollider = col;
                }
                if (rb.velocity.y <= 0)
                {
                    up = false;
                }
            }
            else if (col.CompareTag("Player"))
            {
                col.gameObject.GetComponent<Player>().hurt(damage);
            }
        }

        public void Damage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Coin.AddCoins(1);
                GetComponentInParent<Spawner>().EnemyDied();

                Destroy(gameObject);
            }
        }

        public float getHealth()
        {
            return health;
        }

        public float getMaxHealth()
        {
            return maxHealth;
        }

        public float getDamage()
        {
            return damage;
        }
    }
}