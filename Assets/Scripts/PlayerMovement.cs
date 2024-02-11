using System;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MapCreator mapCreater;
    [SerializeField] private float _distance = 3f;
    [SerializeField] private float _minX, _maxX;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] public int num = 0;
    private Vector3 _targetPosition;
    private Vector3 _prePosition;
    private void Start()
    {
        var position = transform.position;
        _targetPosition = _startPos = position;
    }

    private void Update()
    {
        var direction = GetInputDirection();

        if (direction == Vector3.zero) { return; }

        if (!IsLimitArea(direction * _distance))
        {
            _prePosition =_targetPosition;
            _targetPosition += direction * _distance;
        } 

        if (transform.position != _targetPosition) { Move(direction); }
    }

    private Vector3 GetInputDirection()
    {
        var direction = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W)) 
        { 
            direction += Vector3.forward;
            mapCreater.LoadMap(); 
        }

        if (Input.GetKeyDown(KeyCode.S)) { direction += Vector3.back; }

        if (Input.GetKeyDown(KeyCode.A)) { direction += Vector3.left; }

        if (Input.GetKeyDown(KeyCode.D)) { direction += Vector3.right; }

        return direction;
    }

    private bool IsLimitArea(Vector3 direction)
    {
        float nowX = _targetPosition.x + direction.x;
        return nowX < _minX || nowX > _maxX;
    }

    private void Move(Vector3 direction) { transform.DOMove(_targetPosition, 0.5f); }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if(CompareTag("DuplicatedPlayer")) Destroy(gameObject);
            
            DOTween.KillAll();
            _targetPosition = _startPos;
            transform.position = _startPos;
        }
        else if (other.CompareTag("Obstacle"))
        {
            _targetPosition = _prePosition;
            Move(_targetPosition);
        }
    }
}