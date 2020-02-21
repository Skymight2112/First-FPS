using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMoto))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private float thrustForce = 1000f;


    [Header("Spring Settings: ")]
    [SerializeField]
    private JointDriveMode jointMode = JointDriveMode.Position;
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;



    private PlayerMoto motor;
    private ConfigurableJoint joint;

    private void Start()
    {
        motor = GetComponent<PlayerMoto>();
        joint = GetComponent<ConfigurableJoint>();

        SetJointSettings(jointSpring);
    }

    private void Update()
    {
        //calcutae movement velocity as a 3D vector
        float xMovment = Input.GetAxisRaw("Horizontal");
        float zMovment = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMovment;
        Vector3 movVertical = transform.forward * zMovment;

        Vector3 _velocity = (movHorizontal + movVertical).normalized* speed;

        motor.Move(_velocity);



        //calcutate CAMERA rotation as a 3D vector(LOOKING UP/DOWN)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;

        motor.rotateCamera(_cameraRotationX);



        //calcutate rotation as a 3D vector(TURNING AROUND)
        float _yRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.rotate(_rotation);


        //calculate Thruster force
        Vector3 _thrusterForce = Vector3.zero;

        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrustForce;
            SetJointSettings(0f);
        }   else
        {
            SetJointSettings(jointSpring);
        }

        //Applying thruster force
        motor.ApplyThruster(_thrusterForce);
    }


    private void SetJointSettings (float _jointSpring)
    {
        joint.yDrive = new JointDrive 
        { 
            mode = jointMode,
            positionSpring = jointSpring,
            maximumForce = jointMaxForce 
        };
    }

}
