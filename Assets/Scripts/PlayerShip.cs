using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    //Initialisation.
    private float Speed = 10f;
    private float Pitch = 0f;
    private float Yaw = 0f;
    private float SteerSpeed = Mathf.PI / 2f;
    private Rigidbody Ship;
    private Transform ShipModel;

    [SerializeField] private InputActionAsset InputActions;
    private InputActionMap FlightControls;

    void Start()
    {
        Ship = GetComponent<Rigidbody>();
        ShipModel = transform.Find("Model");
        FlightControls = InputActions.FindActionMap("FlightControls");
    }
    //.

    //Controls go here.
    void FixedUpdate()
    {
        //Acceleration.
        if (FlightControls.FindAction("Forwards").IsPressed())
        {
            MoveForward(Time.fixedDeltaTime);
        }
        if (FlightControls.FindAction("Backwards").IsPressed())
        {
            MoveForward(Time.fixedDeltaTime * -1f);
        }
        //.

        //Steering.
        if (FlightControls.FindAction("SteerLeft").IsPressed())
        {
            SteerShip(0f, -SteerSpeed, Time.fixedDeltaTime);
        }
        if (FlightControls.FindAction("SteerRight").IsPressed())
        {
            SteerShip(0f, SteerSpeed, Time.fixedDeltaTime);
        }
        if (FlightControls.FindAction("PitchUp").IsPressed())
        {
            SteerShip(SteerSpeed, 0f, Time.fixedDeltaTime);
        }
        if (FlightControls.FindAction("PitchDown").IsPressed())
        {
            SteerShip(-SteerSpeed, 0f, Time.fixedDeltaTime);
        }
        //.
    }
    //.

    //Moves the ship forward.
    void MoveForward(float Delta)
    {
        Vector3 ForwardVector = Mathsy.FindForward(Pitch, Yaw);
        Vector3 MoveVector = Mathsy.Scale(ForwardVector, Speed * Delta);
        Vector3 NewPosition = Ship.position + MoveVector;

        Ship.MovePosition(NewPosition);
    }
    //.

    //Steer the ship.
    void SteerShip(float AddPitch, float AddYaw, float Delta)
    {
        Pitch += AddPitch * Delta;
        Yaw += AddYaw * Delta;

        FaceModelForward();
    }
    //.

    //Rotate model to face forward.
    void FaceModelForward()
    {
        Vector3 ForwardVector = Mathsy.FindForward(Pitch, Yaw);
        ShipModel.rotation = Quaternion.LookRotation(ForwardVector * -1f, ShipModel.up);
    }
    //.
}
