using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Nova : EnemyWeaponBase
{
    public override Vector3 CalculateBulletTrajectory(Vector3 rot)
    {
        return new Vector3(0, (360 / ShotCount) * this.CurrentShot, 0);
    }
}
