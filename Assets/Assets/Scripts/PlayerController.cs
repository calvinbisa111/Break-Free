    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PlayerController : MonoBehaviour
    {
        bool isIdle = true;
        bool isJump = true;
        bool isDead = false;
        bool doubleJump;
        int idMove = 0;
        Animator anim;
        private bool isAttacking = false;
        private bool hasKey = false;
        private string currentLevel = "";

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource doublejumpSoundEffect;
    [SerializeField] private AudioSource trapSoundEffect;
    [SerializeField] private AudioSource runSoundEffect;



    private void Start()
        {
            anim = GetComponent<Animator>();
             currentLevel = SceneManager.GetActiveScene().name;

    }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("Jump "+isJump);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
                runSoundEffect.Play();
        }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
                runSoundEffect.Play();
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Idle();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Idle();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                Attack();
            }
            Move();
            Dead();

    }

        private void OnCollisionStay2D(Collision2D collision)
        {
            // Kondisi ketika menyentuh tanah
            if (isJump)
            {
                anim.ResetTrigger("jump");
                if (idMove == 0) anim.SetTrigger("idle");
                isJump = false;
            }

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            // Kondisi ketika menyentuh tanah
            anim.SetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("attack");
            anim.ResetTrigger("idle");
            isJump = true;
        }

        public void MoveRight()
        {
            idMove = 1;
        }
        public void MoveLeft()
        {
            idMove = 2;
        }

        private void Move()
        {
            if (idMove == 1 && !isDead)
            {
                
            // Kondisi ketika bergerak ke kekanan
            if (!isJump) anim.SetTrigger("run");
                transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
                transform.localScale = new Vector3(9f, 9f, 1f);
                
            }
            if (idMove == 2 && !isDead)
            {
                
                // Kondisi ketika bergerak ke kiri
                if (!isJump) anim.SetTrigger("run");
                transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
                transform.localScale = new Vector3(-9f, 9f, 1f);
                
            }
        }

        public void Jump()
        {
            if (!isJump)
            {
                jumpSoundEffect.Play();
                // Kondisi ketika Loncat
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
                doubleJump = true;
                isIdle = false;
            }
            else if (doubleJump)
            {
                doublejumpSoundEffect.Play();
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200f);
                doubleJump = false;
                anim.SetTrigger("doublejump");
            }

        }

        public void Idle()
        {
            // kondisi ketika idle/diam
            if (!isJump)
            {
                anim.ResetTrigger("jump");
                anim.ResetTrigger("run");
                anim.ResetTrigger("attack");
                anim.SetTrigger("idle");
                runSoundEffect.Stop();
                doublejumpSoundEffect.Stop();
            }
            idMove = 0;
        }
        private void Attack()
        {
            isAttacking = true;
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("idle");
            anim.SetTrigger("attack");
            idMove = 0;
        }
    public void AttackFinished()
    {
        isAttacking = false;
        anim.ResetTrigger("attack"); // Pastikan Anda mereset trigger "attack"
        anim.SetTrigger("idle");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (!isDead)
            {
                if (collision.gameObject.CompareTag("trap"))
                {
                    trapSoundEffect.Play();
                    Die();
                }

                if (collision.transform.tag.Equals("peluru"))
                {
                    Die();
                }
            }


    }
        private void Dead()
        {
            if (!isDead)
            {
                
            }
        }

    public void TakeDamage()
    {
        Debug.Log("Player takes damage.");
        if (!isDead)
        {
            Die();
        }
    }
    public void Die()
        {   
            isDead = true;
            anim.SetTrigger("death"); 
            Debug.Log("Pemain mati");

            StartCoroutine(GameOverDelay());

    }

        private IEnumerator GameOverDelay()
            {
                 yield return new WaitForSeconds(1.0f); // Wait for 1 second
                 PlayerPrefs.SetString("LastLevel", currentLevel);
                    SceneManager.LoadScene("Gameover");
            }

    private void OnTriggerEnter2D(Collider2D collision)
        {

        if (collision.CompareTag("Key"))
            {
                hasKey = true;
                Destroy(collision.gameObject);
                Debug.Log("Pemain telah mengambil kunci.");
            }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("DoorWin"))
        {
            SceneManager.LoadScene("Win");
        }
    }


}


