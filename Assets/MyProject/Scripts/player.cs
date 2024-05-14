using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour, IDamageble
{
    #region variables
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private Slider _slider;
    [SerializeField] private charprogress _progress;
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private int _maxHealth = 100;
    private Vector3 _input;
    private Camera _camera;
    private int _health;
    private bool _alive = true;
    [SerializeField] private TMP_Text _textcoin;
    private static int _loot;
    private static int _coin;
    public int Coin => _coin;
    public static void OnCoin(int a)
    {
        _coin += a;
        print(a);
        _loot = 0;
    }
    public static void OnLoot(int a)
    {
        _loot += a;
    }
    public static int Loot => _loot;
    public int Health => _health;

    public EventHandler<int> TakeDamage => OnTakeDmg;
    #endregion
    private void Start()
    {
        _maxHealth = _progress._charinfo[_progress.Level].MaxHp;
        _health = _maxHealth;
        _alive = _health > 0;
        _camera = Camera.main;

    }
    #region old
    /*
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
    */
    #endregion
    private void OnTakeDmg(object sender, int damage)
    {
        _particleSystem.Play();
        //if (sender is not attack)
          //  return;
        _animator.SetTrigger("Damage");
        print("удар по персонажу");
        if (_health > damage)
            _health -= damage;
        else if (_alive)
        {
            _alive = false;
            _health = 0;
            Die();
        }
    }
    private void Die()
    {
        print("Dead");
        _animator.SetBool("Death",true);
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        _slider.value = (float)_health / 100;
        _textcoin.text = $"Coin:{Coin}";
        print(_health);
        if (Input.GetKey(KeyCode.LeftShift)) _speed = 6;
        else _speed = 3;
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _input = new Vector3(horizontal, 0, vertical);
        Vector3 movementVector = _camera.transform.TransformDirection(_input);
        movementVector.y = 0;
        movementVector.Normalize();
        transform.forward = movementVector;

        _characterController.Move(movementVector * (_speed * Time.deltaTime));
        _animator.SetFloat("Speed", _characterController.velocity.magnitude);
    }
}