using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMusicMapReader : MonoBehaviour
{
    public string mapFilePath;

    [System.Serializable]
    private class Map
    {
        public string _version;
        public List<Note> _notes;
        public int _bpm;
    }

    [System.Serializable]
    public class Note
    {
        public float _time;
        public int _lineIndex;
    }

    private List<Note> _notes = new List<Note>();
    private int _bpm;

    private void Awake()
    {
        TextAsset mapData = Resources.Load<TextAsset>(mapFilePath);
        Map map = JsonUtility.FromJson<Map>(mapData.text);

        _notes = map._notes;
        _bpm = map._bpm;
    }

    public List<Note> GetNotes()
    {
        return _notes;
    }

    public int GetBpm()
    {
        return _bpm;
    }
}