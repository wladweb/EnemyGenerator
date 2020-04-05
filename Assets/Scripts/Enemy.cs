using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Vector3 _destination;

    private void Awake()
    {
        _destination = Random.insideUnitCircle * 100;
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);
    }
}
