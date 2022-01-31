using UnityEngine;

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

        private bool grounded;
        private bool jumping;

        private bool facingRight;

        private int maxJump;
        public int totalJump;

        public AudioClip fxJump;

        void Start()
        {
            isDead = false;
            maxJump = 0;
            grounded = true;
            facingRight = true;
            
            rb2D = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>(); 
        }

        private void Update()
        {
            if (isDead)
                return;

            grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

            if (Input.GetButtonDown("Jump") && maxJump > 0)
            {
               
                grounded = false;
                jumping = true;
            }

            if (grounded)
            {
                maxJump = totalJump;
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

        private void SetAnimations()
        {
            anim.SetBool("Walk", (rb2D.velocity.x != 0f));
            anim.SetFloat("VelY", rb2D.velocity.y);
            anim.SetBool("JumpFall", !grounded);
        }
    }
}