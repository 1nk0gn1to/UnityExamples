using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private Transform _transform;
    private float _moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var directionForward = _transform.forward * Input.GetAxisRaw("Vertical");
        var directionHorizontal = _transform.right * Input.GetAxisRaw("Horizontal");

        _transform.position += (directionForward + directionHorizontal) * _moveSpeed * Time.deltaTime;
    }
}
