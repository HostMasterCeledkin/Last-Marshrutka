using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform _transformFL;
    [SerializeField] private Transform _transformFR;
    [SerializeField] private Transform _transformBL;
    [SerializeField] private Transform _transformBR;

    [SerializeField] private WheelCollider _colliderFL;
    [SerializeField] private WheelCollider _colliderFR;
    [SerializeField] private WheelCollider _colliderBL;
    [SerializeField] private WheelCollider _colliderBR;

    [SerializeField] private float _force = 1500f;
    [SerializeField] private float _maxAngle = 30f;

    private void FixedUpdate()
    {
        // Движение (исправлено направление)
        float move = -Input.GetAxis("Vertical");

        // Передний привод (как у Оки)
        _colliderFL.motorTorque = move * _force;
        _colliderFR.motorTorque = move * _force;


        // Тормоз на Space
        if (Input.GetKey(KeyCode.Space))
        {
            _colliderFL.brakeTorque = 3000f;
            _colliderFR.brakeTorque = 3000f;
            _colliderBL.brakeTorque = 3000f;
            _colliderBR.brakeTorque = 3000f;
        }
        else
        {
            _colliderFL.brakeTorque = 0f;
            _colliderFR.brakeTorque = 0f;
            _colliderBL.brakeTorque = 0f;
            _colliderBR.brakeTorque = 0f;
        }


        // Поворот
        float steer = Input.GetAxis("Horizontal");

        _colliderFL.steerAngle = steer * _maxAngle;
        _colliderFR.steerAngle = steer * _maxAngle;


        // Обновление положения колёс
        RotateWheel(_colliderFL, _transformFL);
        RotateWheel(_colliderFR, _transformFR);
        RotateWheel(_colliderBL, _transformBL);
        RotateWheel(_colliderBR, _transformBR);
    }


    private void RotateWheel(WheelCollider collider, Transform wheel)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        wheel.position = position;
        wheel.rotation = rotation;
    }
}