using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    [SerializeField] private List<Stone> stones;

    [SerializeField] private float destroyPower;

    private void Start()
    {
        for (int i = 0; i < stones.Count; i++)
        {
            stones[i].SetDestroyPower(destroyPower);
        }
    }

    public void FreeMoveAll()
    {
        for (int i = 0; i < stones.Count; i++)
        {
            stones[i].FreeMove();
        }
    }
}
