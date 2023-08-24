using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private DestroyWall destroyWall;

    [SerializeField] private float destroyPower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Rigidbody2D>() != null)
        {
            if (collision.transform.GetComponent<Rigidbody2D>().inertia * collision.transform.GetComponent<Rigidbody2D>().velocity.magnitude > 1)
            {
                destroyWall.FreeMoveAll();
            }
        }
    }

    public void FreeMove()
    {
        rigidbody2D.freezeRotation = false;
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
    }

    public void SetDestroyPower(float newDestroyPower)
    {
        destroyPower = newDestroyPower;
    }
}
