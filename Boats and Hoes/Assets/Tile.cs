using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game;

namespace Game
{
	public class Tile
	{
		List<Edge> m_edges;
		int m_id;
		string m_textureName;
		Vector2 m_position;

		public Tile() : this (-1)
		{
		}

		public Tile(int id) : 
			this(new List<Edge> ((int)(Edge.EdgeType.MAX_EDGES)), id)
		{
		}

		public Tile(List<Edge> edges, int id)
		{
			m_edges = edges;
			m_id = id;
			m_textureName = "";
			m_position = new Vector2();
		}

		public void SetEdge(Edge.EdgeType type, Edge Edge)
		{
			m_edges[(int)type] = Edge;
		}

		public void SetTexture(string texture)
		{
			m_textureName = texture;
		}

		// Update is called once per frame
		void Update()
		{
		
		}

		List<Edge> FindMatchingEdges(Tile other)
		{
			List<Edge> matches = new List<Edge>();

			return matches;
		}

		bool DoesEdgeMatch(Edge edge)
		{
			bool bMatches = true;
			return bMatches;
		}
	}
}
