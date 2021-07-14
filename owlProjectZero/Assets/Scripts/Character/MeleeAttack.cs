using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    MeleeAttack(float dmg, int start, int active, int lag, float gkb, float gAngle, float akb, float aAngle) : base(dmg, start, active, lag, gkb, gAngle, akb, aAngle)
    {}
}
