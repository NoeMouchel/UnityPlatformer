using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCapsule : Loot
{
    public int m_try_point = 1;

    protected override bool CanBeAbsorbed(PlayerController pc)
    {
        return !pc.m_tp.IsMax();
    }

    protected override void Use(PlayerController pc)
    {
        pc.m_tp.Increase(m_try_point);
        Destroy(gameObject);
    }
}
