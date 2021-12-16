using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZER : MonoBehaviour
{
    Pool source;
    float chrono;

    [SerializeField] float speed;
    [SerializeField] float speedLazerMove;
    [SerializeField] float maxLife;
    public Vector2 moveLazer;

    [SerializeField] GameObject preLazer;
    [SerializeField] GameObject child;
    [SerializeField] GameObject childLazer;

    [SerializeField] Material alphaChange;
    Material changeMat;
    public Color color = new Color();
    // Start is called before the first frame update

    private void Start()
    {
        chrono = maxLife;

        changeMat = new Material(alphaChange);
        SoundManager.Instance.PlayPrelaser();
        color = changeMat.color;
        color.a = 0.1f;
        changeMat.color = color;
        preLazer.GetComponent<SpriteRenderer>().material = changeMat;
    }

    private void Update()
    {
        color = changeMat.color;
        color.a += 1f * Time.deltaTime * speed;
        changeMat.color = color;

        moveLazer.x += Time.deltaTime * speedLazerMove;
        childLazer.transform.localPosition = moveLazer;

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
        SoundManager.Instance.PlayLaunchLaser();
        child.SetActive(true);
    }
}
