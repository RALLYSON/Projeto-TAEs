using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound
{
    //public string nome;
    public AudioClip clip;
    private AudioSource source;
    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;

    }
    //public void Play()
    //{
    //    source.Play();

    //}
    //public void Stop()
    //{
    //    source.Stop();

    //}

}
public class Audio_Gerenciamento : MonoBehaviour {
    [SerializeField]
    Sound[] sounds;
    bool tocandoSom;
    AudioSource[] audioSources;
    // Use this for initialization
    void Start () {
        audioSources = new AudioSource[sounds.Length];
        tocandoSom = true;
		for(int i=0; i < sounds.Length; i++)
        {
            GameObject obj = new GameObject("Sound_" + i + "_" + sounds[i].clip.name);
            obj.transform.SetParent(this.transform);
            sounds[i].SetSource(obj.AddComponent<AudioSource>());
            audioSources[i] = obj.GetComponent<AudioSource>();
            obj.GetComponent<AudioSource>().loop = true;
            obj.GetComponent<AudioSource>().Play();
        }
	}

	public void PlaySoundButton( string _nome)
    {
        if(tocandoSom)  //se o som está tocando (ativado) ele para o som
        {
            PauseSom(_nome);
            return;
        }
        TocarSom(_nome); // se o som não esta tocando , ele da play
        
        //Debug.LogWarning(" (Audio Gerenciamento.PlaySound) Audio não encontrado !");
    }

    public void TocarSom(string _nome)
    {
        tocandoSom = true;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].clip.name == _nome)
            {
                audioSources[i].Play();
                return;
            }
        }
    }
    public void PauseSom(string _nome)
    {
        tocandoSom = false;
        for (int i = 0; i < audioSources.Length; i++)
        {
            print(audioSources[i].clip.name);
            if (audioSources[i].clip.name == _nome)
            {
                audioSources[i].Pause();
                return;
            }
        }
        Debug.LogWarning(" (Audio Gerenciamento.StopSound) Audio não encontrado!");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
