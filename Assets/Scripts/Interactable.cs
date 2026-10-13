using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log($"Interacted with {name}");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
