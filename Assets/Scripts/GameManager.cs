using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public ArrayList threadArray = new ArrayList();
    // public ArrayList philosophersArray = new ArrayList();
    public Philosopher[] philosophers;
    // private Thread thread;
    public bool handleStart = true;

    void Start()
    {
        foreach (var element in philosophers)
        {
            element.handleLoop = handleStart;
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void Start_Ordered_Demo()
    {

        
        foreach (Thread element in threadArray)
        {
            element.Abort();
        }
        
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(new ThreadStart(philosophers[i].startAction));
            thread.Start();
            threadArray.Add(thread);
        }
    }

    public void Stop_Ordered_Demo()
    {
        Debug.Log("Stop");
        foreach (Thread i in threadArray)
        {
            i.Abort();
            foreach (var each in philosophers) 
            {
                each.actionlog = "idle";
                //Debug.Log(each.textMesh.text);
            }
        }
    }
    
    public void triggerAnimation(Philosopher philosopher)
    {
        // philosophers.GetComponent<Renderer>().material.color = Color.cyan;
        Debug.Log("Hello");
    }
}
