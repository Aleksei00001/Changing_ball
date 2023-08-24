using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    [SerializeField] private GameObject targetPosition;

    private void Update()
    {
        this.transform.position = new Vector3(targetPosition.transform.position.x, targetPosition.transform.position.y, -10);
    }
}
