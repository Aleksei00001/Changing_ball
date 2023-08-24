using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private bool m_Spike;
    public bool spike => m_Spike;

    [SerializeField] private bool m_Bursting;
    public bool bursting => m_Bursting;

    [SerializeField] private bool m_Sticky;
    public bool sticky => m_Sticky;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Wall>() == true)
        {
            Wall wall = collision.transform.GetComponent<Wall>();

            if (wall.bursting == true && spike == true)
            {
                Destroy(wall.gameObject);
            }
        }

    }
}
