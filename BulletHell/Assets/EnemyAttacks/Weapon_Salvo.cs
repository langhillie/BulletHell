using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Salvo : EnemyWeaponBase
{
    public override Vector3 CalculateBulletTrajectory(Vector3 rot)
    {
        return new Vector3(0, (30 / ShotCount) * this.CurrentShot - 15, 0);
    }
}
