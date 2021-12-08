using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZER : MonoBehaviour
{
    Pool source;
    float chrono;
    [SerializeField] float maxLife;
    [SerializeField] GameObject child;
    // Start is called before the first frame update

    private void Start()
    {
        chrono=maxLife;
    }
    
    private void Update()
    {
        if (chrono <= 0)
        {
            LAZERSpawn();
            chrono=maxLife;
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
