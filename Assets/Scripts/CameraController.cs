using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerController target;
    [SerializeField]
    private Vector3 targetOffset;
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera() {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + targetOffset, target.movSpeed * Time.deltaTime);
        Debug.Log("");
       // Vector3 moveDir = new Vector3(50f, target.moveDir.y, target.moveDir.z);
        //transform.forward = Vector3.Lerp(transform.forward, target.moveDir, 10f * Time.deltaTime);
    }
}
