using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Game;

namespace Game
{
	public class Tile : UnityEngine.Object
	{
		static readonly string TEXTURE_PATH = "Assets/Resources/metadata/";
		List<Edge> m_edges;
		List<FeatureSegment> m_featureSegments;
		int m_id;
		string m_textureName;
		Vector2 m_position;
		GameObject gameObj;

		public Tile() : this (-1, "")
		{
		}

		public Tile(int id, string texture)
		{
			gameObj = (GameObject)Instantiate(Resources.Load("Tile", typeof(GameObject)));

			m_id = id;
			SetTexture(texture);
			m_position = new Vector2();
			m_featureSegments  = new List<FeatureSegment>();

			m_edges = new List<Edge>((int)Edge.EdgeType.MAX_EDGES);
			for(int i = 0; i < m_edges.Capacity; i++)
			{
				m_edges.Add(null);
			}
		}

		// Copy tile with unique id
		public Tile(int id, Tile tile) : this(id, tile.m_textureName)
		{
			// must create feature segments before creating edges since
			// edges point to feature segments
			foreach(FeatureSegment seg in tile.m_featureSegments)
			{
				FeatureSegment newSeg = new FeatureSegment(seg);
				m_featureSegments.Add(newSeg);
			}

			for(int i = 0; i < m_edges.Capacity; ++i)
			{
				Edge newEdge = new Edge(this, tile.m_edges[i]);
				m_edges[i] = newEdge;
			}
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		public FeatureSegment GetFeatureSegment(int id)
		{
			foreach(FeatureSegment seg in m_featureSegments)
			{
				if(seg.GetId() == id)
				{
					return seg;
				}
			}

			return null;
		}

		public void SetEdge(Edge.EdgeType type, Edge Edge)
		{
			m_edges[(int)type] = Edge;
		}

		public void SetTexture(string texture)
		{
			m_textureName = texture;
			LoadTexture();
		}

		private void LoadTexture()
		{
			if (m_textureName != "" && gameObj != null)
			{
				SpriteRenderer myRenderer = gameObj.GetComponent<SpriteRenderer>();
				Texture2D newTexture = Resources.LoadAssetAtPath(TEXTURE_PATH + m_textureName, typeof(Texture2D)) as Texture2D;
				Sprite newSprite = Sprite.Create(newTexture, new Rect(0, 0, 128, 128), new Vector2());
				myRenderer.sprite = newSprite;
			}
		}

		public void AddFeatureSegment(FeatureSegment newSeg)
		{
			m_featureSegments.Add(newSeg);
		}

		public void PrintInfo()
		{
			Debug.Log("Tile id - " + m_id + ", texture - " + m_textureName);
			foreach(FeatureSegment seg in m_featureSegments)
			{
				seg.PrintInfo();
			}
			foreach(Edge edge in m_edges)
			{
				edge.PrintInfo();
			}
		}
	}
}
