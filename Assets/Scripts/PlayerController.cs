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

    ScoreManager scoreManager;

    bool canControlPlayer = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float previousRotation = 0f;
    float totalRotation = 0f;
    int flipCount = 0;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (canControlPlayer) {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
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

    void CalculateFlips(){
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation > 340 || totalRotation < -340)
        {
            flipCount++;
            totalRotation = 0f;
            print("Flip " + flipCount);
            scoreManager.AddScore(100);
        }
        previousRotation = currentRotation;
    }

    public void DisableControl()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }
    }

    public void DeactivatePowerup(PowerupSO powerup){
        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }
    }
}
