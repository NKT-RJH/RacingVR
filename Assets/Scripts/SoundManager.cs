using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioSource audioSource;

	// ���� �ֱ�!
}

[System.Serializable]
public class Sounds
{
	public AudioClip idle;
	public AudioClip drift;
	public AudioClip brake;
}