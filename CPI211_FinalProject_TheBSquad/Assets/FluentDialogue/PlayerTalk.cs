using UnityEngine;
using Fluent;

public class PlayerTalk : MonoBehaviour
{
    public static PlayerTalk Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            FluentManager.Instance.ExecuteClosestAction(gameObject);
        }

    }
}

