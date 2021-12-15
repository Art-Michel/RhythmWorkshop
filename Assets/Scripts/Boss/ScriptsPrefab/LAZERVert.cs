using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZERVert : MonoBehaviour
{
    Pool source;
    float chrono;
    [SerializeField] float maxLife;
    [SerializeField] GameObject child;
    [SerializeField] Material alphaChange;
    [SerializeField] float speed;
    Vector2 moveLazer;
    Material changeMat;
    Color color = new Color();
    // Start is called before the first frame update

    private void Start()
    {
        chrono = maxLife;
        moveLazer=child.transform.position;

        changeMat = new Material(alphaChange);
        color = changeMat.color;
        color.a = 0.1f;
        changeMat.color = color;
        gameObject.GetComponent<SpriteRenderer>().material = changeMat;
    }

    private void Update()
    {
        color = changeMat.color;
        color.a += 1f * Time.deltaTime * speed;
        changeMat.color = color;

        moveLazer.y-=Time.deltaTime;
        child.transform.position=moveLazer;
        if (chrono <= 0)
        {
            LAZERSpawn();
            chrono = maxLife;
        }
        chrono -= Time.deltaTime;
    }

    public void Spawn(Pool pool)
    {
        child.SetActive(false);
        source = pool;
    }

    public void Return(Pool pool)
    {
        color = changeMat.color;
        color.a = 0.1f;
        changeMat.color = color;
        child.SetActive(false);
        source.Back(gameObject);
    }

    void LAZERSpawn()
    {
        child.SetActive(true);
    }
}
