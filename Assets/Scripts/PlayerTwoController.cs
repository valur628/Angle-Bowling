using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public float PlayerMoveSpeed = 10.0f; //플레이어 속도

    private bool KeyUp = false;
    private bool KeyDown = false;
    private bool KeyLeft = false;
    private bool KeyRight = false;

    void Update()
    {

        if (GameMainManager.GamePulse == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.eulerAngles = new Vector3(PlayerMoveSpeed, 0, 0);
                KeyUp = true;
                KeyDown = false;
                KeyLeft = false;
                KeyRight = false;
            }
            else if (KeyUp == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.eulerAngles = new Vector3(-PlayerMoveSpeed, 0, 0);
                KeyUp = false;
                KeyDown = true;
                KeyLeft = false;
                KeyRight = false;
            }
            else if (KeyDown == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, PlayerMoveSpeed);
                KeyUp = false;
                KeyDown = false;
                KeyLeft = true;
                KeyRight = false;
            }
            else if (KeyLeft == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, -PlayerMoveSpeed);
                KeyUp = false;
                KeyDown = false;
                KeyLeft = false;
                KeyRight = true;
            }
            else if (KeyRight == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if(GameMainManager.GamePulse == true)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (GameMainManager.PlayerTwoTimerReset == true)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
