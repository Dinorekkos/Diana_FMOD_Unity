using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Kar_Flying : MonoBehaviour
{
    [SerializeField] private GameObject parachute;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private GroundChecker checker;
    

    private float _normalMass = 250;
    private bool _isFlying = false;
    private bool _isGrounded = false;
    void Start()
    {
        maxScale = transform.localScale;
        parachute.transform.localScale = Vector3.zero;
        checker.OnGrounded += OnPlayerStopFlying;

    }

    void Update()
    {
        
        if (groundCheck.transform.position.y > 1)
        {
            _isGrounded = false;
        }
        else
        {
            _isGrounded = true;
        }

        if (!_isFlying && _isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerStartFlying();
            }
        }
        
    }

    private void PlayerStartFlying()
    {
        _isFlying = true;
        parachute.transform.DOScale(maxScale, 1.5f).SetEase(Ease.OutBounce);
        DoJump();
    }
    
    private void OnPlayerStopFlying()
    {
        if (_isFlying)
        {
            Debug.Log("OnPlayerStopFlying");
             rb.mass = 250f;
             Debug.Log("rb.mass = " + rb.mass);
             parachute.transform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InBounce);
            _isFlying = false;

        }
    }

    private void DoJump()
    {
        rb.mass = 60f;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
    }
    
    
}
