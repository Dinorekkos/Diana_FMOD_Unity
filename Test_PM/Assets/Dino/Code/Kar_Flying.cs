using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Kar_Flying : MonoBehaviour
{
    [SerializeField] private GameObject parachute;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float flyingMass;

    private float _normalMass;
    private bool _isFlying = false;
    void Start()
    {
        _normalMass = rb.mass;
        maxScale = transform.localScale;
        parachute.SetActive(false);
    }

    void Update()
    {
        if (_isFlying) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerStartFlying();
        }
    }

    private void PlayerStartFlying()
    {
        _isFlying = true;
        parachute.transform.localScale = Vector3.zero;
        parachute.SetActive(true);
        parachute.transform.DOScale(maxScale, 1.5f).SetEase(Ease.OutBounce);
        transform.DOJump(transform.position + Vector3.one, jumpHeight, 1, jumpDuration);
    }
    
    private void OnPlayerStopFlying()
    {
        rb.mass = flyingMass;
        parachute.transform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InBounce);
    }
    
    
}
