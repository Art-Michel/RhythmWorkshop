using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZER : MonoBehaviour
{
    Pool source;
    float chrono;
    [SerializeField] float maxLife;
    [SerializeField] GameObject child;
    [SerializeField] Material alphaChange;
    [SerializeField] float speed;
    public Color color = new Color();
    // Start is called before the first frame update

    private void Start()
    {
        chrono = maxLife; 
        color = alphaChange.color;
        color.a = 0.1f;
        alphaChange.color = color;
    }

    private void Update()
    {
        color = alphaChange.color;
        color.a += 1f * Time.deltaTime * speed;
        alphaChange.color = color;

        if (chrono <= 0)
        {
            LAZERSpawn();
            chrono = maxLife;
        }
        chrono -= Time.deltaTime;
    }

    public void Spawn(Pool pool)
    {
        source = pool;
    }

    public void Return(Pool pool)
    {
        source.Back(gameObject);
    }

    void LAZERSpawn()
    {
        child.SetActive(true);
    }
}
