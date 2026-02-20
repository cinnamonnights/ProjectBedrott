using UnityEngine;
using UnityEngine.InputSystem;

public class BedrottPlayer : MonoBehaviour
{
  CharacterController _bedrottController;
  Vector3 _move;
  float _verticalVelocity;
  bool _isDead = false;
  [SerializeField] float _moveSpeed = 10f;
  
  //JumpStuff
  [SerializeField] float _jumpForce = 5f;
  [SerializeField] float _gravity = -9.81f;

  public LayerMask _groundLayer;
  public float _groundCheckDistance;

  void Awake()
  {
    _bedrottController = GetComponent<CharacterController>();
  }
  void Start()
  {
    StartGame();
  }
  public void StartGame()
  {
    _isDead = false;
    _verticalVelocity = 0f;
    _move = Vector3.zero;
  }
  public void OnMove(InputValue value)
  {
    Vector2 move = value.Get<Vector2>();
    _move = new Vector3(move.x, 0, move.y);
    Debug.Log($"Move: {_move}");
  }

  public void OnJump(InputValue value)
  {
    if (value.isPressed && _bedrottController.isGrounded)
    {
      _verticalVelocity = _jumpForce;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Hazard"))
    {
      BedrottGameManager01.Instance.GameOver();
    }
  }
  //Update is called once per frame
  void Update()
  {
    if (_isDead) return;

    //Ground Check
    if (_bedrottController.isGrounded && _verticalVelocity < 0)
    {
      _verticalVelocity = -2f; // Small downward force to stay grounded
    }
    // Apply gravity
    _verticalVelocity += _gravity * Time.deltaTime;

    //Note: Multiplying the vector last is an optimization compared to multiplying it first
    _bedrottController.Move((_moveSpeed *
    //We rotate the move vector by the Y-axis of the transform to make it relative to the camera
    //Note: Quaternion * Vector3 is a rotation of the vector, but we can not use Vector3 * Quaternion
    (Quaternion.Euler(0, transform.eulerAngles.y, 0) * _move) +
    Vector3.up * _verticalVelocity) * Time.deltaTime);
  }
  
}
