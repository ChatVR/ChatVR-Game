using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerController : MonoBehaviour
{
    [Range(0,10)]
    public float playerSpeed;

    public GameObject playerCamera;

    void Start()
    {
    }

    void Update()
    {
        Vector2 inp = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        if (inp == Vector2.zero) return;

        Vector3 facingForward = Utils.toXZPlane(playerCamera.transform.forward).normalized;
        Vector3 facingSide = Utils.toXZPlane(playerCamera.transform.right).normalized;
        transform.Translate((facingForward*inp.y+facingSide*inp.x)*playerSpeed*Time.deltaTime);
    }

}
