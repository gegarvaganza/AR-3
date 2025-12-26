using UnityEngine;

public class DiscoLight : MonoBehaviour
{
    private Light _discoLight; 
    [SerializeField] private float changeInterval = 0.5f; 

    private void Start()
    {
        _discoLight = GetComponent<Light>(); 
        InvokeRepeating(nameof(ChangeLightColor), time:0f, repeatRate:changeInterval); 
    }

    private void ChangeLightColor()
    { 
        var randomColor = new Color(r:Random.value, g:Random.value, b:Random.value); 
        _discoLight.color = randomColor; 
    }
}