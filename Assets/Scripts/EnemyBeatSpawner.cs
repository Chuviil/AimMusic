using System.Collections.Generic;
using UnityEngine;

public class EnemyBeatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyBeatPrefab;
    [SerializeField] private Transform spawnOriginLeft;
    [SerializeField] private Transform spawnOriginRight;

    private List<AimMusicMapReader.Note> _notes;

    private int _nextNoteIndex = 0;

    private AudioSource _audioSource;

    // Time interval between beats
    private float _beatInterval;

    private void Start()
    {
        AimMusicMapReader mapReader = GetComponent<AimMusicMapReader>();
        _notes = mapReader.GetNotes();

        _audioSource = GetComponent<AudioSource>();

        // Calculate the time interval between beats
        _beatInterval = 60.0f / mapReader.GetBpm();

        _audioSource.Play();
    }

    private void Update()
    {
        if (_nextNoteIndex < _notes.Count && _audioSource.time >= _notes[_nextNoteIndex]._time * _beatInterval)
        {
            // Spawn a note
            Transform spawnOrigin = _notes[_nextNoteIndex]._lineIndex % 2 == 0 ? spawnOriginLeft : spawnOriginRight;
            Instantiate(enemyBeatPrefab, spawnOrigin.position, spawnOrigin.rotation);

            _nextNoteIndex++;
        }
    }
}