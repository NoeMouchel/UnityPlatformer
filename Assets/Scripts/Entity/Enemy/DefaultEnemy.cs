using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy
{
    private new void Update()
    {
        LinearDisplacement();

        base.Update();
    }
}
