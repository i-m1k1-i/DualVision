using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager Instance;

    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _enemyDeathSound;
    [SerializeField] private AudioClip _playerHitSound;
    [SerializeField] private AudioClip _shotSoundPlayer;
    [SerializeField] private AudioClip _shotSoundEnemy;

    private AudioSource _audioSource;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayExplosionSound()
    {
        _audioSource.PlayOneShot(_explosionSound);
    }

    public void PlayShotSound(bool isPlayer)
    {
        if (isPlayer)
        {
            _audioSource.PlayOneShot(_shotSoundPlayer, 0.5f);
        }
        else
        {
            _audioSource.PlayOneShot(_shotSoundEnemy, 0.5f);
        }
    }

    public void PlayEnemyDeathSound()
    {
        _audioSource.PlayOneShot(_enemyDeathSound);
    }

    public void PlayPlayerHitSound()
    {
        _audioSource.PlayOneShot(_playerHitSound, 0.3f);
    }
}
