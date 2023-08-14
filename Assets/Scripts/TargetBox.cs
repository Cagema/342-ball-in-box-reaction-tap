using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBox : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _length;
    float _timer = 0;
    Vector3 _startPos;
    private void Start()
    {
        _startPos = transform.position;
    }
    private void FixedUpdate()
    {
        if (GameManager.Single.Score >= 10)
        {
            _timer += Time.deltaTime;
            transform.position = new Vector3(_startPos.x, _startPos.y + (Mathf.Sin(_timer * _speed) * _length), _startPos.z);
        }
    }
}
