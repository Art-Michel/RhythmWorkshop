using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int baseCount;

    Queue<GameObject> items = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        AddCount(baseCount);
    }

    public GameObject Get()
    {
        if (items.Count == 0)
            AddCount(1);

        return items.Dequeue();
    }

    public void Back(GameObject obj)
    {
        obj.SetActive(false);
        items.Enqueue(obj);
    }

    public void AddCount(int nb)
    {
        for (int i = 0; i < nb; i++)
        {
            GameObject go = Instantiate(prefab, transform);
            go.SetActive(false);
            items.Enqueue(go);
        }
    }
}
