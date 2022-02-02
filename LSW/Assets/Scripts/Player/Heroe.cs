using LSW.Managers;
using LSW.MenuGame;
using LSW.Static;
using LSW.Zombies;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LSW.Heroe
{
    public class Heroe : MonoBehaviour
    {
        [Header("Configs Player - SCriptable Objects")]
        [SerializeField]
        private Player player;
        [SerializeField]
        private MenuInGame _menuInGame;
        [SerializeField]
        private GamePlayManager _gamePlayManager;

        private Rigidbody2D rb2D;
        private Animator anim;
        private bool isDead;
        private int health;
        private int speed;

        [SerializeField]
        private Transform groundCheck;
        private SpriteRenderer sprite;
        private bool grounded;
        private bool jumping;
        private bool facingRight;
        private int maxJump;

        //Attack
        public Transform spawnAttack;
        public GameObject attackPrefab;
        private float nextAttack;

        //Sounds
        private AudioSource fxSource;
        public AudioClip fxHurt;
        public AudioClip fxJump;
        public AudioClip fxAttack;
        public AudioClip fxScore;

        private bool protectHealth;
        //Getters and Setters
        public Player Player { get => player; set => player = value; }

        void Start()
        {
            protectHealth = false;
            isDead = false;
            maxJump = 0;
            grounded = true;
            facingRight = true;
            nextAttack = 0f;
            rb2D = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
            fxSource = GetComponent<AudioSource>();

            //Data Life Hero
            health = DataGame.CurrentHealthHero;
            speed = player.Speed;
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
                maxJump = player.TotalJump;

            if (Input.GetButtonDown("Fire1") && grounded && Time.time > nextAttack && !anim.GetBool("Walk"))
                Attack();

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
                rb2D.AddForce(new Vector2(0f, player.Jumpforce));
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isDead)
                return;

            if (other.CompareTag("Zombie") && !protectHealth)
            {
                DamagePlayer();
            }

            if (other.CompareTag("FloorDead"))
                Invoke("ReloadLevel", 1f);

            if (other.CompareTag("ScoreCristal"))
                PlaySound(fxScore);

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

            protectHealth = false;
        }
        private void PlaySound(AudioClip clip)
        {
            fxSource.clip = clip;
            fxSource.Play();
        }


        private void DamagePlayer()
        {
            health--;
            DataGame.CurrentHealthHero = health;
            _menuInGame.RefreshHealth(health);

            PlaySound(fxHurt);

            if (health <= 0)
            {
                //Chama o popup de fim de jogo
                _gamePlayManager.GameOver(false);

                 isDead = true;
                speed = 0;
                rb2D.velocity = new Vector2(0f, 0f);
                anim.SetTrigger("HeroeDead");
            }
            else
            {
                protectHealth = true;
                StartCoroutine(DamageEffect());
            }
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        }

        private void Attack()
        {
            PlaySound(fxAttack);

            anim.SetTrigger("Attack");
            nextAttack = Time.time + player.AttackRate;

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