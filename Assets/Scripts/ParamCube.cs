using UnityEngine;

public class ParamCube : MonoBehaviour
{

    public int band;
    public float startScale;
    public float scaleMultiplier;
    public bool useBuffer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            foreach (float i in AudioPeer.bandBuffer)
            {
                Debug.Log(i);
                Debug.Log(" ");
            }
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.bandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }

        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }
        
    }
}
