using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpead;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpead * Time.deltaTime));
    }
}
