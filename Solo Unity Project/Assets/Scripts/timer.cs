using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float elapsedTime;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        text.text = elapsedTime.ToString();
    }
}
