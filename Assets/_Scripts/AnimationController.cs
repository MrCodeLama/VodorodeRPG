using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> allAnimations;

    private Vector3 normalScale = new Vector3(2,2,1);
    void Start()
    {
        foreach (var destination in allAnimations)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
