using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    float leftClickCooldown;
    [SerializeField]
    Bullet b;
    [SerializeField]
    Transform weaponPosition;

    private int playerAtk { get; set; }

    [SerializeField]
    List<AudioClip> shootingSFXs;

    float leftTimer;

    void Start()
    {
        playerAtk = 5;
    }
    private void Update()
    {
        if (!GetComponent<PlayerCollision>().isDead)
        {
            LeftClick();

            RightClick();

            MidClick();

            updateTimer();
        }
    }

    void updateTimer()
    {
        if (leftTimer > 0)
        {
            leftTimer -= Time.deltaTime;
        } else if (leftTimer <= 0)
        {
            leftTimer = 0;
        }
    }

    void LeftClick()
    {
        // If clicked and not in cooldown
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Left Clicked");
            if (leftTimer == 0)
            {
                Debug.Log("SHOOT");
                
                AudioSystem.Instance.PlaySFX(shootingSFXs[Random.Range(0, shootingSFXs.Count)]);
                // Instantiate Bullet
                Bullet bullet = Instantiate(b);
                bullet.transform.forward = transform.forward;
                bullet.transform.position = weaponPosition.position;

                // Enter Cooldown Cycle
                leftTimer = leftClickCooldown;
            }
            else
            {
                Debug.Log("ON CD");
                // Placeholder
            }
        }
    }

    public void IncrementAtk()
    {
        playerAtk += 5;
    }

    void RightClick()
    {
        // Placeholder
    }

    void MidClick()
    {
        // Placeholder
    }

}
