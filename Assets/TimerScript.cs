using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class TimerScript : MonoBehaviour
{
    public float laptime = 0;
    private bool isTriggered = false;

    public UnityEngine.UI.Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered == true){
            laptime += Time.deltaTime;
            timerText.text = "Time: " + laptime.ToString("F2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Start"){
            isTriggered = true;
        }

        if(other.gameObject.name == "Finish"){

            isTriggered = false;
            IEnumerator wait(){
                yield return new WaitForSeconds(5);
                timerText.text = "";}
            StartCoroutine(wait());
        }
    }
}
