using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerActionMap _inputs;
    CharacterController _charaCon;
    bool _isMoving;
    Vector2 _wantedDirection;
    [SerializeField] float _speed;
    float _easeInValue;
    [SerializeField] float _easeInSpeed;

    [SerializeField] GameObject _playerBody;

    private void Awake()
    {
        _inputs = new PlayerActionMap();
        _inputs.Movement.Move.started += ReadMovementInputs;
        _inputs.Movement.Move.canceled += StopReadingMovementInputs;
    }

    private void Start()
    {
        _charaCon = GetComponent<CharacterController>();
        _isMoving = false;
        _wantedDirection = Vector2.zero;
        _easeInValue = 0;
    }

    private void Update()
    {
        if (_isMoving)
        {
            EaseInMovement();
            Move();
        }
    }

    private void ReadMovementInputs(InputAction.CallbackContext obj)
    {
        _isMoving = true;
        _easeInValue = 0;
    }

    private void StopReadingMovementInputs(InputAction.CallbackContext obj)
    {
        _isMoving = false;
        _wantedDirection = Vector2.zero;
    }

    private void EaseInMovement()
    {
        if (_easeInValue < 1)
        {
            _easeInValue += Time.deltaTime * _easeInSpeed;
            _easeInValue = Mathf.Clamp(_easeInValue, 0, 1);
        }
    }

    private void Move()
    {
        _wantedDirection = _inputs.Movement.Move.ReadValue<Vector2>();
        _charaCon.Move(_wantedDirection * _speed * _easeInValue * Time.deltaTime);


        _playerBody.transform.up = Vector3.Lerp(_playerBody.transform.up, _wantedDirection, 20 * Time.deltaTime);
    }

    #region disable inputs on Player disable to avoid weird inputs
    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }
    #endregion
}
