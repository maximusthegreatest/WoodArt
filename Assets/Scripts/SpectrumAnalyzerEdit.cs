using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Attach this script below a GameObject with an AudioSource and manually assign a clip and enable Play on Awake.
/// Since this script does not care what song is playing you can implement an Audio manager to change songs as you wish.
/// Make sure to manually assign two prefabs of your choice.
/// </summary>
public class SpectrumAnalyzer : MonoBehaviour
{
    public AnalyzerSettings settings; //All of our settings
    AudioSource _audioSource;
    public static float[] samples = new float[512];

    //private
    private float[] spectrum; //Audio Source data

    [SerializeField]
    public List<GameObject> blocks;

    [SerializeField]
    public int maxLevel;
    
    
    


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    


    void Update()
    {
        GetSpectrumAudioSource();

        


        for (int i = 0; i < blocks.Count; i++) //needs to be <= sample rate or error
        {
            float level = samples[i]*settings.pillar.sensitivity*Time.deltaTime*1000; //0,1 = l,r for two channels
            if (level > maxLevel)
            {
                level = 5;
            }
            //Scale pillars 
            Vector3 previousScale = blocks[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, level, settings.pillar.speed*Time.deltaTime);
                //Add delta time please
            blocks[i].transform.localScale = previousScale;

            
        }
    }


    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

} 