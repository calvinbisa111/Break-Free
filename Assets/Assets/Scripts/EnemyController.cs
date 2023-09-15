using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float shootingRange = 10f;
    public float shootingCooldown = 2f;
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    private Animator animator;
    private bool isPlayerInRange = false;
    private bool isDead = false;
    private bool canShoot = true;

    private float shootingTimer = 0f;
    private int health = 100;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        Vector3 arahPlayer = player.position - transform.position;
        float jarakKePlayer = arahPlayer.magnitude;

        if (jarakKePlayer <= shootingRange)
        {
            isPlayerInRange = true;

            if (shootingTimer <= 0)
            {
                StartShooting();
                shootingTimer = shootingCooldown;
            }
        }
        else
        {
            isPlayerInRange = false;
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
            {
                Idle();
            }
        }

        shootingTimer -= Time.deltaTime;

        // Menghadap ke kanan jika player ada di sebelah kanan
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
    }

    private void StartShooting()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            animator.SetTrigger("shoot");
        }
        // Implementasi logika untuk memulai menembak
    }

    private void Idle()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("idle");
        }
        
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("death");
    }

    
}