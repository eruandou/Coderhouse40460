using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isGrounded = false;
    [SerializeField] private string objectName = "jorge";
    [SerializeField] private int characterAge = 32;
    [SerializeField] private float speed = 3.5f;
    private double fallingSpeed = -9.81d;
    private Vector3 absolutePosition = new Vector3(10.5f, 5.1f, 3);
    [SerializeField] private Vector3 movementDir = new Vector3(0, 15, -2);

    private void Awake()
    {
        characterAge = 10;
        Debug.Log("Awake");
        var isSpeedValid = speed > 0;
        var nameIsValid = string.IsNullOrWhiteSpace(objectName);
        // Debug.LogError("is speed valid? " + isSpeedValid);
        Debug.Assert(isSpeedValid, "Speed is invalid");
        Debug.Assert(nameIsValid, "Name is invalid");
    }

    public void SetCharacterName(string newName)
    {
        objectName = newName;
    }

    public string GetCharacterName()
    {
        return objectName;
    }

    public double GetFallingSpeed()
    {
        return fallingSpeed;
    }

    // Start is called before the first frame update
    public void Start()
    {
        // Debug.Log(characterAge);
        //
        // transform.position = new Vector3(0, 15, -2);
        // transform.localScale = new Vector3(3, 1, 4);
        // transform.rotation = Quaternion.Euler(new Vector3(45, 0, 176));
        Debug.Log("Start");
    }

    public void Move(float p_speed, Vector3 p_movementDir, Transform p_movingEntity)
    {
        p_movingEntity.position += CalculateDisplacement(p_movementDir, p_speed);

        Print1To9();
    }

    private Vector3 CalculateDisplacement(Vector3 p_movementDir, float p_speed)
    {
        var displacement = p_movementDir * Time.deltaTime * p_speed;
        return displacement;
    }

    public void TeleportEntity(Vector3 p_newPosition, Transform p_entity)
    {
        p_entity.position = p_newPosition;
    }

    private void Print1To9()
    {
        Debug.LogError("1");
        Debug.LogError("2");
        Debug.LogError("3");
        Debug.LogError("4");
        Debug.LogError("5");
        Debug.LogError("6");
        Debug.LogError("7");
        Debug.LogError("8");
        Debug.LogError("9");
        Debug.LogError("10");
    }


    // Update is called once per frame
    void Update()
    {
        // characterAge /= 2;
        // characterAge *= 2;
        // characterAge = characterAge + 1;
        // characterAge += 1;
        // characterAge++;
        // Debug.Log(transform.position);
        Move(speed, movementDir, transform);
        Debug.Log("10");
    }
}
