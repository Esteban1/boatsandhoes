using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Game;

namespace Game
{
	public class Tile
	{
		List<Edge> m_edges;
		List<FeatureSegment> m_featureSegments;
		int m_id;
		string m_textureName;
		Vector2 m_position;

		public Tile() : this (-1, "")
		{
		}

		public Tile(int id, string texture)
		{
			m_id = id;
			m_textureName = texture;
			m_position = new Vector2();
			m_featureSegments  = new List<FeatureSegment>();

			m_edges = new List<Edge>((int)Edge.EdgeType.MAX_EDGES);
			for(int i = 0; i < m_edges.Capacity; i++)
			{
				m_edges.Add(null);
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
