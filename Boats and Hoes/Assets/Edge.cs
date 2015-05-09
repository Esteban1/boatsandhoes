// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
	public class Edge
	{
		readonly Tile m_parentTile;
		List<FeatureSegment> m_segments;
		EdgeType m_type;

		public static readonly int NUM_SEGMENTS = 3;

		public enum EdgeType
		{
			TOP,
			RIGHT,
			BOTTOM,
			LEFT,
			MAX_EDGES
		}

		public Edge(Tile parentTile, EdgeType type)
		{
			m_parentTile = parentTile;
			m_type = type;

			m_segments = new List<FeatureSegment>(NUM_SEGMENTS);
			for(int i = 0; i < m_segments.Capacity; ++i)
			{
				m_segments.Add(null);
			}
		}

		public EdgeType GetEdgeType()
		{
			return m_type;
		}

		public void SetFeatureSegment(int segIdx, FeatureSegment featSeg)
		{
			if(segIdx < 0 || segIdx >= m_segments.Capacity)
			{
				Debug.LogError("Edge.SetFeatureSegment - Segment index " + segIdx + " out of range");
				return;
			}
			m_segments[segIdx] = featSeg;
		}

		public void PrintInfo()
		{
			Debug.Log("    Edge type - " + m_type);
			foreach(FeatureSegment seg in m_segments)
			{
				Debug.Log("        Feature segment - " + seg.GetId());
			}
		}
	}
}

