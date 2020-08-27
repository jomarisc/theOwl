using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    void MoveCharacter(float direction);
    void Jump();
    void Attack();
    void Dodge();
    void GetRekt();
    void GoToDamagedState(float damageAmount, float knockback);
}
