using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallPassSystem_CS : MonoBehaviour
{
    private int maxHallPassCount = 3;
    private int defaultHallPassCount = 0;
    private int currentHallPassCount;

    // Start is called before the first frame update
    void Start()
    {
        currentHallPassCount = defaultHallPassCount;
    }

    // Update is called once per frame
    void Update()
    {
        SetMaxHallPassCount();
    }

    private void SetHallPassCount() 
    {
        currentHallPassCount = defaultHallPassCount;
    }

    private void SetMaxHallPassCount() 
    {
        if (currentHallPassCount >= maxHallPassCount) currentHallPassCount = maxHallPassCount;
    }

    public int GetCurrentHallPassCount() 
    {
        int currentCount = currentHallPassCount;
        return currentCount;
    }

    public void AddHallPass() 
    {
        currentHallPassCount ++;
    }
}
