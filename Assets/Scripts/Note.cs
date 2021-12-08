using UnityEngine;

public class Note : MonoBehaviour
{
    public Vector3 NoteDirection;
    [SerializeField] float _speed = 5;
    [SerializeField] float _lifeSpan = 3;
    float timer = 0;

    private void Update()
    {
        transform.position += (NoteDirection * _speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > _lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
