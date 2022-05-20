using UnityEngine;

public class AutoWheel : MonoBehaviour
{

    [SerializeField] private float _rotateMultiplayer = 1f;

    private void Update()
    {
        transform.Rotate(_rotateMultiplayer * Mathf.PI * transform.position);
    }
}
