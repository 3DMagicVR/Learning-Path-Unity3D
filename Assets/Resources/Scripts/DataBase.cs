using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    int valueA, valueB;
    List<int> values = new List<int>();
    Vector3 positionNew;
    MonoBehaviour component;

    public Manager(int valueA, int valueB)
    {
        this.valueA = valueA;
        this.valueB = valueB;
        positionNew = component.gameObject.transform.position;
    }

    public int ValueA
    {
        get;
        private set;
    }

    public int ValueB
    {
        get
        {
            return valueB;
        }
    }
}

public class DataBase : MonoBehaviour
{
    public static DataBase dataBase;
    public Manager manager;

    private void Awake()
    {
        manager = new Manager(1, 2);

        if (dataBase == null)
        {
            dataBase = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("Current values on manager: {0} - {1}", manager.ValueA, manager.ValueB);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
