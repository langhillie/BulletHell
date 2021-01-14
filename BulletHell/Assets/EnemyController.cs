using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health = 20;
    private float MovementSpeed = 1f;
    private MovementModes MovementMode;
    private float FireRate = 2.5f;
    private float FireCooldown = 2f;
    private float CreationTime;

    [SerializeField]
    private EnemyWeaponBase Weapon;

    public enum MovementModes
    {
        Sin,
        Track,
        FireAndLeave,
        Linear,
    }

    public void Initialize(MovementModes MovementMode, float FireRate, float Health = 20f, float MovementSpeed = 1f)
    {
        this.MovementMode = MovementMode;
        this.FireRate = FireRate;
        this.Health = Health;
        this.MovementSpeed = MovementSpeed;
        CreationTime = Time.timeSinceLevelLoad;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (MovementMode)
        {
            case MovementModes.Sin:
                transform.position = transform.position + Vector3.down * MovementSpeed * Time.deltaTime + new Vector3(Mathf.Sin(Time.timeSinceLevelLoad - CreationTime) / 200, 0, 0);
                break;
            case MovementModes.FireAndLeave:
                break;
            case MovementModes.Track:
                break;
            case MovementModes.Linear:
                transform.position = transform.position + transform.forward * MovementSpeed * Time.deltaTime;
                break;
        }

        if (FireCooldown > 0)
        {
            FireCooldown -= Time.deltaTime;
        }
        else
        {
            FireCooldown = FireRate;
            Weapon.Shoot();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Health -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);

            if (Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameBoundries"))
        {
            Destroy(this.gameObject);
        }
    }
}