using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LSW.Heroe
{
    public class Heroe : MonoBehaviour
    {
        private Rigidbody2D rb2D;
        private Animator anim;

        public bool isDead;
        public int health;

        [SerializeField]
        private int speed;
        [SerializeField]
        private float jumpforce;
        [SerializeField]
        private Transform groundCheck;

        private SpriteRenderer sprite;
        private bool grounded;
        private bool jumping;

        private bool facingRight;

        private int maxJump;
        public int totalJump;

        //Attack
        public float attackRate;
        public Transform spawnAttack;
        public GameObject attackPrefab;
        private float nextAttack;

        //Sounds
        private AudioSource fxSource;
        public AudioClip fxHurt;
        public AudioClip fxJump;
        public AudioClip fxAttack;

        void Start()
        {
            isDead = false;
            maxJump = 0;
            grounded = true;
            facingRight = true;
            nextAttack = 0f;
            rb2D = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
            fxSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (isDead)
                return;

            grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

            if (Input.GetButtonDown("Jump") && maxJump > 0)
            {
                PlaySound(fxJump);
                grounded = false;
                jumping = true;
            }

            if (grounded)
            {
                maxJump = totalJump;
            }

            if (Input.GetButtonDown("Fire1") && grounded && Time.time > nextAttack && !anim.GetBool("Walk"))
            {
                Attack();
            }

            SetAnimations();
        }

        private void FixedUpdate()
        {
            if (isDead)
                return;

            float move = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

            if ((move < 0f && facingRight) || (move > 0f && !facingRight))
            {
                facingRight = !facingRight;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            if (jumping)
            {
                maxJump--;
                jumping = false;

                rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
                rb2D.AddForce(new Vector2(0f, jumpforce));
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isDead)
                return;

            if (other.CompareTag("Zombie"))
                DamagePlayer();

            if (other.CompareTag("FloorDead"))
                Invoke("ReloadLevel", 1f);
        }

        IEnumerator DamageEffect()
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(.1f);
            sprite.enabled = false;
            yield return new WaitForSeconds(.1f);
            sprite.enabled = true;
        }
        public void PlaySound(AudioClip clip)
        {
            fxSource.clip = clip;
            fxSource.Play();
        }


        private void DamagePlayer()
        {
            health--;
            PlaySound(fxHurt);

            if (health == 0)
            {
                isDead = true;
                speed = 0;
                rb2D.velocity = new Vector2(0f, 0f);
                anim.SetTrigger("HeroeDead");
                Invoke("ReloadLevel", 1f);
            }
            else
            {
                StartCoroutine(DamageEffect());
            }
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene("Tier1", LoadSceneMode.Single);
        }

        private void Attack()
        {
            PlaySound(fxAttack);

            anim.SetTrigger("Attack");
            nextAttack = Time.time + attackRate;

            GameObject cloneAtk = Instantiate(attackPrefab, spawnAttack.position, spawnAttack.rotation);

            if (!facingRight)
            {
                cloneAtk.transform.eulerAngles = new Vector3(180, 0, 180);
            }
        }


        private void SetAnimations()
        {
            anim.SetBool("Walk", (rb2D.velocity.x != 0f));
            anim.SetFloat("VelY", rb2D.velocity.y);
            anim.SetBool("JumpFall", !grounded);
        }
    }
}