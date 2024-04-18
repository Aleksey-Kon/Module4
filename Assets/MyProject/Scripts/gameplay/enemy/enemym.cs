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

    private float _currentSpeed = 0f;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _text.text = _health.ToString();
            if (_agent.hasPath && _currentSpeed < _maxSpeed)
            {
                _currentSpeed += _speedIncrase * Time.deltaTime;
            }

            if (!_agent.hasPath)
            {
                _currentSpeed = 0f;
                _agent.SetDestination(TakeNewPath());
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
