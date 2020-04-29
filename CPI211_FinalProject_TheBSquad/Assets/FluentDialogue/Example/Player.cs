using UnityEngine;
using Fluent;

public class Player : MonoBehaviour 
{
    public static Player Instance;

    void Awake()
    {
        Instance = this;
    }

	void Start () 
    {
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FluentManager.Instance.ExecuteClosestAction(gameObject);
        }
	
	}
}
