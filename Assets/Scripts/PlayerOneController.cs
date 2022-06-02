using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOneController : MonoBehaviour
{
    public float PlayerMoveSpeed = 10.0f; //플레이어 속도

    private bool KeyW = false;
    private bool KeyS = false;
    private bool KeyA = false;
    private bool KeyD = false;

    void Update()
    {
        if (GameMainManager.GamePulse == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.eulerAngles = new Vector3(PlayerMoveSpeed, 0, 0);
                KeyW = true;
                KeyS = false;
                KeyA = false;
                KeyD = false;
            }
            else if (KeyW == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.eulerAngles = new Vector3(-PlayerMoveSpeed, 0, 0);
                KeyW = false;
                KeyS = true;
                KeyA = false;
                KeyD = false;
            }
            else if (KeyS == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, PlayerMoveSpeed);
                KeyW = false;
                KeyS = false;
                KeyA = true;
                KeyD = false;
            }
            else if (KeyA == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, -PlayerMoveSpeed);
                KeyW = false;
                KeyS = false;
                KeyA = false;
                KeyD = true;
            }
            else if (KeyD == true)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (GameMainManager.GamePulse == true)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
            if (GameMainManager.PlayerOneTimerReset == true)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}

