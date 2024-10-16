using UnityEngine;

public class PoisonFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoisonPlayer()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }
}
