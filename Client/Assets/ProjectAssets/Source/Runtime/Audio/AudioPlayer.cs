using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = default;
    void Start()
    {
       audioSource.Play();
    }
}
