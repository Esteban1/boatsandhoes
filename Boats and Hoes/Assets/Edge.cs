// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Game
{
	public class Edge
	{
		public enum EdgeType
		{
			EDGE_TOP,
			EDGE_RIGHT,
			EDGE_BOTTOM,
			EDGE_LEFT,
			MAX_EDGES
		}

		List<Segment> segs;

		public Edge ()
		{
			segs = new List<Segment> (3);
		}

		public void SetSegment(int segIdx, Segment seg)
		{
			segs [segIdx] = seg;
		}
	}
}

