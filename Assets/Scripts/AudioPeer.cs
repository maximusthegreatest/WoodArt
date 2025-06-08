using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    
    AudioSource _audioSource;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    public float[] _bufferDecrease = new float[8];


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBand();
        BandBuffer();
        
        
    }


    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if (freqBand[g] > bandBuffer[g])
            {                
                bandBuffer[g] = freqBand[g];
                _bufferDecrease[g] = .5f;
            }


            if (freqBand[g] < bandBuffer[g])
            {                
                bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBand()
    {

        int count = 0;

        for(int i=0; i < 8; i++)
        {

            float average = 0;            
            int sampleCount = (int) Mathf.Pow(2, i) * 2;


            //so we get all the samples in the spectrum
            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }


            average /= count;

            freqBand[i] = average * 10;


        }

    }

}
