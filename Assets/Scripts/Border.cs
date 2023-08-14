using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] bool _left;

    private void Start()
    {
        if (_left)
        {
            transform.position = Vector3.left * GameManager.Single.RightUpperCorner.x;
        }
        else
        {
            transform.position = Vector3.right * GameManager.Single.RightUpperCorner.x;
        }
    }
}
