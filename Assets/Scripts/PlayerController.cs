using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    Vector2 moveVector;

    bool canControlPlayer = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (canControlPlayer) {
            RotatePlayer();
            BoostPlayer();
        }
    }

    void RotatePlayer()
    {
        if (moveVector.x > 0)
        {
            myRigidbody2D.AddTorque(-torqueAmount);
        }
        else if (moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount);
        }
    }
    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed; 
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    public void DisableControl()
    {
        canControlPlayer = false;
    }
}
