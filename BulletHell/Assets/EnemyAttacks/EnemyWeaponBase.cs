using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyWeaponBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject BulletPrefab;

    [SerializeField]
    protected int ShotCount;
    [SerializeField]
    protected float DelayBetweenBullets;
    protected int CurrentShot = 0;
    protected float BulletCooldown = 2f;

    [SerializeField]
    protected float FireRate = 2.5f;
    protected float FireCooldown = 2f;


    private void Update()
    {
        if (this.BulletCooldown > 0)
        {
            this.BulletCooldown -= Time.deltaTime;
        }

        if (this.BulletCooldown <= 0 && CurrentShot > 0)
        {
            ShootBullet(CalculateBulletTrajectory(transform.forward));
            BulletCooldown = this.DelayBetweenBullets;
            CurrentShot--;
        }
    }

    public void Shoot()
    {
        if (this.DelayBetweenBullets == 0)
        {
            for (this.CurrentShot = ShotCount; this.CurrentShot > 0; this.CurrentShot--)
            {
                ShootBullet(CalculateBulletTrajectory(transform.forward));
            }
        }
        else
        {
            this.CurrentShot = this.ShotCount;
        }
    }

    public void ShootBullet(Vector3 BulletTrajectory)
    {
        GameObject bullet = GameObject.Instantiate(this.BulletPrefab, transform.position, transform.rotation);
        bullet.transform.Rotate(BulletTrajectory);
        bullet.tag = "EnemyBullet";
        bullet.GetComponent<Bullet>().StartSpeed = 5f;
        bullet.GetComponent<Bullet>().EndSpeed = 2f;
        bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public abstract Vector3 CalculateBulletTrajectory(Vector3 ShipForward);
}
