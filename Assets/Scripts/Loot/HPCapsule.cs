using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCapsule : Loot
{
    public int m_heal_point = 1;

    protected override bool CanBeAbsorbed(PlayerController pc)
    {
        return !pc.m_hp.IsMax();
    }

    protected override void Use(PlayerController pc)
    {
        pc.m_hp.Increase(m_heal_point);
        Destroy(gameObject);
    }

}
