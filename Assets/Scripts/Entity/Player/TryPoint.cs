using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryPoint : PointSystem
{
    private new void Start()
    {
        base.Start();
    }
    private void Update()
    { 
        if (IsMin())
        {
            Debug.Log("INFO : Game Over");
        }
    }
}
