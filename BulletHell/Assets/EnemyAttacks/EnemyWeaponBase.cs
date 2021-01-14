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
    protected float DelayBetweenShots;


    protected int CurrentShot = 0;
    protected float FireCooldown = 2f;

    private void Update()
    {
        if (this.FireCooldown <= 0 && CurrentShot > 0)
        {
            ShootBullet(CalculateBulletTrajectory(transform.forward));
            FireCooldown = this.DelayBetweenShots;
            CurrentShot--;
        }
        else if (this.FireCooldown > 0)
        {
            this.FireCooldown -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (this.DelayBetweenShots == 0)
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
        bullet.GetComponent<Bullet>().Speed = 2f;
        bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public abstract Vector3 CalculateBulletTrajectory(Vector3 ShipForward);
}
