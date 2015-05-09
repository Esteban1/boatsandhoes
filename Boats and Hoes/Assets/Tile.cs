using UnityEngine;
using System.Collections;
using Game;

public class Tile : MonoBehaviour 
{
	Side[] m_sides;
	int m_id;
	string m_textureName;

	// Use this for initialization
	void Start () 
	{
		m_sides = new Side[4];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
