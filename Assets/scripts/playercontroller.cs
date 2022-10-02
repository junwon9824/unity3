using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float walkspeed;



    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentcameraRotationX=0;

    [SerializeField]
    private Camera theCamera;
    
    private Rigidbody myRigid;


    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraRotation();
        characterrotation();
    }

    private void Move()
    {
       float _moveDirX =Input.GetAxisRaw("Horizontal");
       float _moveDirZ =Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward* _moveDirZ;
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkspeed;
        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }
    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX= _xRotation*lookSensitivity;
        currentcameraRotationX -= _cameraRotationX;
        currentcameraRotationX = Mathf.Clamp(currentcameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentcameraRotationX, 0f, 0f);
    }
    public void characterrotation()
    {
        //аб©Л
        float _yrotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterroationY = new Vector3(0f, _yrotation, 0f)*lookSensitivity;
        myRigid.MoveRotation( myRigid.rotation * Quaternion.Euler(_characterroationY));

    }
}
