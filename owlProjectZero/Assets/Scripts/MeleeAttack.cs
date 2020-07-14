using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    MeleeAttack(float dmg, int start, int active, int lag, float kb, float angle) : base(dmg, start, active, lag, kb, angle)
    {}
}
