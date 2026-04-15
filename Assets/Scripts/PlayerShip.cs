using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerShip : MonoBehaviour
{
    //Initialisation.
    private float Speed = 10f;
    private float Pitch = 0f;
    private float Yaw = 0f;
    private float SteerSpeed = Mathf.PI / 2f;
    private Rigidbody Ship;

    [SerializeField] private InputActionAsset InputActions;
    private InputActionMap FlightControls;

    void Start()
    {
        Ship = GetComponent<Rigidbody>();
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
            SteerShip(0f, -SteerSpeed);
        }
        if (FlightControls.FindAction("SteerRight").IsPressed())
        {
            SteerShip(0f, SteerSpeed);
        }
        if (FlightControls.FindAction("PitchUp").IsPressed())
        {
            SteerShip(SteerSpeed, 0f);
        }
        if (FlightControls.FindAction("PitchDown").IsPressed())
        {
            SteerShip(-SteerSpeed, 0f);
        }
        //.
    }
    //.

    //Moves the ship forward.
    void MoveForward(float Delta)
    {
        Vector3 ForwardVector = Mathsy.FindForward(Pitch, Yaw);
        Vector3 MoveVector = Mathsy.Scale(ForwardVector, Speed * Delta * -1f);
        Vector3 NewPosition = Ship.position + MoveVector;

        Ship.MovePosition(NewPosition);
    }
    //.

    //Steer the ship.
    void SteerShip(float AddPitch, float AddYaw)
    {
        transform.Rotate(AddPitch, AddYaw, 0f, Space.Self);

        Vector3 CurrentAngle = transform.localEulerAngles;
        Pitch = Mathsy.DegreeToRadian(-CurrentAngle.x);
        Yaw = Mathsy.DegreeToRadian(CurrentAngle.y);
    }
    //.
}
