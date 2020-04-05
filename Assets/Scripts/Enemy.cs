using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Vector3 _destination;
    private bool _isFacingRight = true;
    private bool _isMoveRight;

    private void Awake()
    {
        _destination = Random.insideUnitCircle * 100;

        if (_destination.x - transform.position.x < 0)
        {
            _isMoveRight = false;
        }
        else
        {
            _isMoveRight = true;
        }

        ChangeDirection();

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

    public void ChangeDirection()
    {
        if (_isMoveRight != _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
