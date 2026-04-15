using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    //Initialisation.
    private Rigidbody ShipBody;
    private GameObject PlayerShip;
    private Vector3 PlayerPosition;

    private float Speed = 10f;

    void Start()
    {
        ShipBody = GetComponent<Rigidbody>();
        
        PlayerShip = GameObject.FindGameObjectWithTag("Player");
        if (PlayerShip != null)
        {
            PlayerPosition = PlayerShip.transform.position;
        }
    }
    //.

    void FixedUpdate()
    {
        FacePlayer();
    }

    void FacePlayer()
    {
        PlayerPosition = PlayerShip.transform.position;
        transform.LookAt(PlayerPosition);
    }
}
