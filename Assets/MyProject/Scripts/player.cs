using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private Vector3 _input;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    public void VoidSetSpeedX(int a)
    {
        _input = new Vector3(a, 0, 0);
    }
    public void VoidSetSpeedY(int b)
    {
        _input = new Vector3(0, 0, b);
    }
    public void Jump(int a)
    {
        _speed = a;
    }
    private void Update()
    {
        
        if(Application.platform != RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.LeftShift)) _speed = 6;
            else _speed = 3;
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            _input = new Vector3(horizontal, 0, vertical);
        }
        Vector3 movementVector = _camera.transform.TransformDirection(_input);
        //_camera.transform.RotateAround()
        movementVector.y = 0;
        movementVector.Normalize();
        transform.forward = movementVector;

        _characterController.Move(movementVector * (_speed * Time.deltaTime));
        _animator.SetFloat("Speed", _characterController.velocity.magnitude);
    }
}