using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContror : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private float addForseLeft;

    [SerializeField] private float addForseRight;

    [SerializeField] private float jampTimer;

    [SerializeField] private float stopTimer;


    [SerializeField] private List<BollTips> bollTips;

    [SerializeField] private bool haveLimit;

    [SerializeField] private List<int> bollLimit;

    [SerializeField] private float swapTimer;

    void Update()
    {
        jampTimer += Time.deltaTime;
        stopTimer += Time.deltaTime;

        if (jampTimer > 0.5)
        {
            if (player.jamp > 0)
            {
                if (Input.GetMouseButtonDown(0) == true)
                {
                    player.AddForseMove(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), addForseLeft);
                    //player.MassSet(1);

                    jampTimer = 0;
                }
            }
        }
        if (stopTimer > 0.5)
        { 
            //if (player.jamp > 0)
            {
                if (Input.GetMouseButtonDown(1) == true)
                {
                    player.stopMove();
                    //player.AddForseMove(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), addForseRight);
                    //player.MassSet(5);

                    stopTimer = 0;
                }
            }
        }

        swapTimer += Time.deltaTime;

        if (swapTimer > 0.5)
        {
            SwapBoll(0, KeyCode.Q);
            SwapBoll(1, KeyCode.W);
            SwapBoll(2, KeyCode.E);
            SwapBoll(3, KeyCode.R);
            //SwapBoll(4, KeyCode.A);
            //SwapBoll(5, KeyCode.S);
            //SwapBoll(6, KeyCode.D);
            //SwapBoll(7, KeyCode.F);
        }
    }

    private void SwapBoll(int bollID, KeyCode keyCode)
    {
        if (bollLimit[bollID] > 0 || haveLimit != true)
        {
            if (Input.GetKeyDown(keyCode) == true)
            {
                player.SetBoll(bollTips[bollID]);
                bollLimit[bollID]--;
                swapTimer = 0;
            }
        }
    }
}
