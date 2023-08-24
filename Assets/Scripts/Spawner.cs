using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;

    [SerializeField] private float time;

    [SerializeField] private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            GameObject newGameObject = Instantiate<GameObject>(gameObject);
            newGameObject.transform.position = transform.position;

            timer = 0;
        }
    }
}
