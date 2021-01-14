using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gm;
    
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float MovementSpeed = 15f;
    [SerializeField]
    private float FireRate = 0.08f; // Seconds of cooldown per shot


    private float InvincibleTime = 0f;
    bool PhasedOut = false;

    private float FireCooldown = 0f;
    private float AlternateFire = -0.1f;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (InvincibleTime > 0)
            InvincibleTime -= Time.deltaTime;
        else if (PhasedOut == true)
        {
            GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            PhasedOut = false;
        }

        Vector2 Move = new Vector2();
        if (Input.GetButton("Horizontal"))
        {
            Move.x = Input.GetAxis("Horizontal");
        }
        if (Input.GetButton("Vertical"))
        {
            Move.y = Input.GetAxis("Vertical");
        }
        transform.position = transform.position + (Vector3)Move * MovementSpeed * Time.deltaTime;

        if (FireCooldown > 0)
        {
            FireCooldown -= Time.deltaTime;
        }
        else 
        {
            FireGun();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (InvincibleTime > 0)
            return;

        if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy"))
        {
            InvincibleTime = 5f;
            GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);

            gm.LostLife();
            Destroy(other.gameObject);
        }
    }

    private void FireGun()
    {
        FireCooldown = FireRate;
        GameObject.Instantiate(BulletPrefab, transform.position + new Vector3(AlternateFire, 0), transform.rotation);
        AlternateFire = -AlternateFire;
    }
}
