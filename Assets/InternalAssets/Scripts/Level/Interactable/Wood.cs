using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public void SetUp(Rigidbody2D joint)
    {
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        GetComponent<Collider2D>().isTrigger = false;

        transform.AddComponent<FixedJoint2D>().connectedBody = joint;
    }
}
