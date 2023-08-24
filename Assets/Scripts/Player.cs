using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BollTips startBollTip;

    [SerializeField] private float mass;

    [SerializeField] private float size;

    [SerializeField] private bool spike;

    [SerializeField] private bool bursting;

    [SerializeField] private bool sticky;

    [SerializeField] private bool movePosible;


    [SerializeField] private SeveZone seveZone;

    [SerializeField] private Sprite sprite;

    [SerializeField] private Color32 color;


    [SerializeField] private int maxJamp;
    [SerializeField] private int m_Jamp;
    public int jamp => m_Jamp;


    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private SpriteRenderer spriteRenderer;



    void Start()
    {
        SetBoll(startBollTip);
        movePosible = true;
    }

    void Update()
    {
        rigidbody2D.mass = mass;
        transform.localScale = new Vector3(size, size, 1);
        spriteRenderer.color = color;
        spriteRenderer.sprite = sprite;
        if (movePosible == false)
        {
            rigidbody2D.gravityScale = 0;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.angularVelocity = 0;
        }
    }

    public void AddForseMove(Vector2 target, float forse)
    {
        if (movePosible == true)
        {
            Vector2 forseVector = new Vector2(target.x - rigidbody2D.transform.position.x, target.y - rigidbody2D.transform.position.y);
            forseVector = forseVector.normalized;
            rigidbody2D.AddForce(forseVector * forse);
            m_Jamp--;
        }
    }

    public void stopMove()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
    }

    public void SetBoll(BollTips bollTips)
    {
        MassSet(bollTips.mass);
        SizeSet(bollTips.size);
        SetSprite(bollTips.sprite);
        SetColor(bollTips.color);
        SetSpike(bollTips.spike);
        SetBursting(bollTips.bursting);
        SetSticky(bollTips.sticky);

        if (sticky == false)
        {
            transform.SetParent(null);
            movePosible = true;
            rigidbody2D.gravityScale = 1;
        }
    }

    public void MassSet(float newMass)
    {
        mass = newMass;
    }

    public void SizeSet(float newSize)
    {
        size = newSize;
    }

    public void SetSprite(Sprite newSprite)
    {
        sprite = newSprite;
    }

    public void SetColor(Color32 newColor)
    {
        color = newColor;
    }

    public void SetSpike(bool newSpike)
    {
        spike = newSpike;
    }

    public void SetBursting(bool newBursting)
    {
        bursting = newBursting;
    }

    public void SetSticky(bool newSticky)
    {
        sticky = newSticky;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Wall>() == true)
        {
            Wall wall = collision.transform.GetComponent<Wall>();

            m_Jamp = maxJamp;

            if (wall.bursting == true && spike == true)
            {
                Destroy(wall.gameObject);
            }

            if (wall.spike == true && bursting == true)
            {
                MoveToSeveZone();
            }

            if (sticky == true)
            {
                transform.SetParent(wall.transform.parent);
                movePosible = false;
            }
        }

        if (collision.transform.GetComponent<SeveZone>() == true)
        {
            SetSeveZone(collision.transform.GetComponent<SeveZone>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Wall>() == true)
        {
            m_Jamp = maxJamp - 1;
        }
    }

    private void MoveToSeveZone()
    {
        transform.position = seveZone.spawnPoint.transform.position;
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.angularVelocity = 0;
    }

    private void SetSeveZone(SeveZone newSeveZone)
    {
        seveZone = newSeveZone;
    }
}
