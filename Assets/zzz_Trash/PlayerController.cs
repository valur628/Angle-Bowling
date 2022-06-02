using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float PlayerMoveSpeed = 5.0f; //플레이어 속도
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.eulerAngles = new Vector3(-PlayerMoveSpeed / 100, 0, 0);

        if (Input.GetKey(KeyCode.D))
            gameObject.transform.eulerAngles = new Vector3(PlayerMoveSpeed / 100, 0, 0);

        if (Input.GetKey(KeyCode.W))
            gameObject.transform.eulerAngles = new Vector3(0, PlayerMoveSpeed / 100, 0);

        if (Input.GetKey(KeyCode.S))
            gameObject.transform.eulerAngles = new Vector3(0, -PlayerMoveSpeed / 100, 0);
    }
}


/*
    public float ForceZ;
    public float ForceX;
    public float BowlingSpeed;
void Start()
    {
        ForceZ = 0.0f;
        ForceX = 0.0f;
        BowlingSpeed = 540.0f;
    }

    void Update()
    {
        ForceZ = Input.GetAxis("Horizontal") * Time.deltaTime * BowlingSpeed;
        ForceX = Input.GetAxis("Vertical") * Time.deltaTime * BowlingSpeed;

        transform.eulerAngles = new Vector3(ForceX, 0.0f, -ForceZ);
    }
 */
