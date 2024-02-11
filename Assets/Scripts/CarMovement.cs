using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private void Update() { transform.Translate(Vector3.forward * (_speed * Time.deltaTime)); }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            Destroy(gameObject);
        }
    }
}