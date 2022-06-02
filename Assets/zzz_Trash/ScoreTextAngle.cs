using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextAngle : MonoBehaviour {

    public GameObject GameObjectAngle;
    public Vector3 GameObjectVector;

	void Start () {
    }
	
	void Update () {
        GameObjectVector = new Vector3(GameObjectAngle.transform.eulerAngles.x, GameObjectAngle.transform.eulerAngles.y, GameObjectAngle.transform.eulerAngles.z);
        transform.eulerAngles = GameObjectVector;
    }
}
