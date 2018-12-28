using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    // Fields with prefabs for procedural generation
    [SerializeField] GameObject fill, hole;
    // Fields that define de min-max values for the holes
    [SerializeField] int min, max;
    // Fields for board content defined distribution
    const int size = 10, space = 2;
    // Use this for random selection item list
    void SetRandomSelection(int row)
    {
        // This are the base values to define a based multiplied distribution
        List<int> slots = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // This is for random selection values storage
        List<int> selected = new List<int>();
        // This set a new seed for random values giving a more randomnes
        int seed = Random.Range(1000, 10000);
        Random.InitState(seed);
        // Using the min-max values;
        int random = Random.Range(min, max);
        // Split the needed values for procedural generation between fills and holes
        while (random >= 0)
        {
            int index = Random.Range(0, slots.Count);
            selected.Add(slots[index]);
            slots.RemoveAt(index);
            random--;
        }
        // To generate the holes
        for (int h = 0; h < selected.Count; h++)
        {
            GameObject go = Instantiate(hole);
            Vector3 newPosition = new Vector3(transform.position.x + (space * selected[h]), transform.position.y + (space * row), 0);
            go.transform.position = newPosition;
        }
        // To generate de fills
        for (int f = 0; f < slots.Count; f++)
        {
            GameObject go = Instantiate(fill);
            Vector3 newPosition = new Vector3(transform.position.x + (space * slots[f]), transform.position.y + (space * row), 0);
            go.transform.position = newPosition;
        }
    }
    // Reload de same scene to re-generate the board
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            SetRandomSelection(i);
        }
    }
}
