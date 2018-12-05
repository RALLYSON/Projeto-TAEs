using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string nome;
    public AudioClip clip;
    private AudioSource source;
    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;

    }
    public void Play()
    {
        source.Play();

    }
    public void Stop()
    {
        source.Stop();

    }

}
public class Audio_Gerenciamento : MonoBehaviour {
    [SerializeField]
    Sound[] sounds;
	// Use this for initialization
	void Start () {
		for(int i=0; i < sounds.Length; i++)
        {
            GameObject gameObject = new GameObject("Sound_" + i + "_" + sounds[i].nome);
            gameObject.transform.SetParent(this.transform);
            sounds[i].SetSource(gameObject.AddComponent<AudioSource>());

        }
        PlaySound("Fur_Elise");
	}
	public void PlaySound( string _nome)
    {
        for(int i=0; i<sounds.Length; i++)
        {
            if (sounds[i].nome == _nome)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning(" (Audio Gerenciamento.PlaySound) Audio não encontrado !");
    }
    public void StopSound(string _nome)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].nome == _nome)
            {
                sounds[i].Stop();
                return;
            }
        }
        Debug.LogWarning(" (Audio Gerenciamento.StopSound) Audio não encontrado!");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
