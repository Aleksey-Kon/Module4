using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class enemym : Enemy
{
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _speedIncrase = 1f;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private Transform _playerTr;
    private float _dist;
    private float _attactcoldown;
    private float _sleep;

    private float _currentSpeed = 0f;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _text.text = _health.ToString();
        _attactcoldown += Time.deltaTime;
        _dist = Vector3.Distance(transform.position, _playerTr.position);
        if (_dist <= 5 && _attactcoldown > 2f)
        {
            gameObject.GetComponent<attack>().SetAttack();
            _attactcoldown = 0f;
        }
        if(_dist <= 5)
        {
            _agent.SetDestination(_playerTr.position);
        }
            if (_agent.hasPath && _currentSpeed < _maxSpeed)
            {
                _currentSpeed += _speedIncrase * Time.deltaTime;
            }
          
            if (!_agent.hasPath)
            {
            _sleep += Time.deltaTime;
            print(_sleep);
            if (_sleep >= 2f) {
                _sleep = 0f;
                _currentSpeed = 0f;
                _agent.SetDestination(TakeNewPath());
            }
            }
        _agent.speed = _currentSpeed;
        _animator.SetFloat("Speed", _currentSpeed);
    }
    protected override void Die()
    {
        _animator.SetBool("Death", true);
        _isAlive = false;
        Destroy(gameObject,2f);
    }
    private Vector3 TakeNewPath()
    {
        NavMeshTriangulation data = NavMesh.CalculateTriangulation();
        int index = Random.Range(0, data.vertices.Length);
        return data.vertices[index];
    }
}
