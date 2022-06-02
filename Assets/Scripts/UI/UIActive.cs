using UnityEngine;
using System.Collections;

public class UIActive : MonoBehaviour
{
    public GameObject ActiveObject;
    public void ObjectEnable()
    {
        ActiveObject.SetActive(true);
    }
    public void ObjectDisable()
    {
        ActiveObject.SetActive(false);
    }
}
