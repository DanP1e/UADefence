using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardWheelRotator : MonoBehaviour
{
    [SerializeField] private float _wheelRotationFactor = 100f;

    public void LookAtDirection(Vector2 direcion) 
    {
        Vector3 direction3d = new Vector3(
            direcion.x, 
            transform.position.y, 
            direcion.y
        ).normalized;

        transform.forward = Vector3.Lerp(
            transform.forward, 
            direction3d, 
            _wheelRotationFactor/100f);
    }
}
