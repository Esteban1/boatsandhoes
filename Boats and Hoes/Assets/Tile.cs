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

		public Tile () : this (-1, "")
		{
		}

		public Tile(int id, string textureName) : 
			this(new List<Edge> ((int)(Edge.EdgeType.MAX_EDGES-1)), id, textureName)
		{
		}

		public Tile(List<Edge> edges, int id, string textureName)
		{
			m_edges = edges;
			m_id = id;
			m_textureName = textureName;
		}

		void SetEdge(Edge.EdgeType type, Edge Edge)
		{
			m_edges [(int)type] = Edge;
		}

		// Update is called once per frame
		void Update () 
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
