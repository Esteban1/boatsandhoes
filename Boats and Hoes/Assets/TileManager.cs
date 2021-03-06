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
using System.Xml;

namespace Game
{
	public class TileManager
	{
		static readonly string ASSET_FILE_NAME = "Assets/Resources/metadata/Tiles";

		Tile m_startingTile;
		List<Tile> m_gameTiles;
		Queue<Tile> m_unusedTiles;
		List<Tile> m_placedTiles;
		List<Tile> m_openSpaceTiles;
		Dictionary<string, int> m_tileCounts;

		public TileManager()
		{

			m_gameTiles = new List<Tile>();
			m_unusedTiles = new Queue<Tile>();
			m_placedTiles = new List<Tile>();
			m_openSpaceTiles = new List<Tile>();
			m_tileCounts = new Dictionary<string,int>();
			XmlDocument xml = XMLReader.Read(ASSET_FILE_NAME);

			int tileID = 0;

			// Tiles
			foreach (XmlNode tileNode in xml.DocumentElement.ChildNodes)
			{
				string texture = tileNode.Attributes["texture"].InnerText;
				int numCopies = int.Parse(tileNode.Attributes["count"].InnerText);
				int edgeCount = 0;

				m_tileCounts[texture] = numCopies;
				Tile newTile = new Tile(tileID, texture);

				foreach (XmlNode childNode in tileNode.ChildNodes)
				{
					if(childNode.Name == "featureSegment")
					{
						int id = int.Parse(childNode.Attributes["id"].InnerText);
						FeatureSegment.FeatureType type = (FeatureSegment.FeatureType)Enum.Parse(typeof(FeatureSegment.FeatureType), childNode.Attributes["type"].InnerText);
						int x = int.Parse(childNode.Attributes["x"].InnerText);
						int y = int.Parse(childNode.Attributes["y"].InnerText);

						FeatureSegment featSeg = new FeatureSegment(id, type, new Vector2(x,y));
						if(childNode.Attributes["multiplier"] != null)
						{
							int multiplier = int.Parse(childNode.Attributes["multiplier"].InnerText);
							featSeg.SetMultiplier(multiplier);
						}

						newTile.AddFeatureSegment(featSeg);
					}
					else if (childNode.Name == "edge")
					{
						if (edgeCount >= (int)Edge.EdgeType.MAX_EDGES)
						{
							Debug.LogError("TileManager.TileManager - Too many edges defined for tile " + tileID);
							break;
						}

						Edge newEdge = new Edge(newTile, (Edge.EdgeType)edgeCount);

						int sectionCount = 0;
						foreach (XmlNode sectionNode in childNode)
						{
							if(sectionNode.Name != "section")
							{
								Debug.LogError("TileManager.TileManager - Expecting node named 'section' for edge " + edgeCount + " of tile " + tileID + " but got node named ' " + sectionNode.Name + "'");
								break;
							}

							if(sectionCount >= Edge.NUM_SEGMENTS)
							{
								Debug.LogError("TileManager.TileManager - Too many sections for edge " + edgeCount + " of tile " + tileID);
								break;
							}

							int featureID = int.Parse(sectionNode.Attributes["featureId"].InnerText);
							FeatureSegment seg = newTile.GetFeatureSegment(featureID);
							if(seg == null)
							{
								Debug.LogError("TileManager.TileManager - Could not find feature segment with id " + featureID + " for section " + sectionCount + " of edge " + edgeCount + " of tile " + tileID);
								break;
							}

							newEdge.SetFeatureSegment(sectionCount++, seg);
						}

						newTile.SetEdge(newEdge.GetEdgeType(), newEdge);
						edgeCount++;
					}
				}

				if (tileID == 0)
				{
					m_startingTile = newTile;
				}
				else
				{
					m_gameTiles.Add(newTile);
				}
				tileID++;

				// Debug
				newTile.PrintInfo();

				// Make copies
				for(int i = 0; i < (numCopies - 1); i++)
				{
					m_gameTiles.Add(new Tile(tileID++, newTile));
				}
			}
		}

		public void NewGame()
		{
			m_unusedTiles.Clear();
			m_placedTiles.Clear();
			m_openSpaceTiles.Clear();

			ShuffleTiles();
			foreach (Tile tile in m_gameTiles)
			{
				m_unusedTiles.Enqueue(tile);
			}
		}

		public void ShuffleTiles()
		{
			for (int i = 0; i < m_gameTiles.Count; ++i)
			{
				int swapIndex = UnityEngine.Random.Range(i + 1, m_gameTiles.Count);
				Tile temp = m_gameTiles[i];
				m_gameTiles[i] = m_gameTiles[swapIndex];
				m_gameTiles[swapIndex] = temp;
			}
		}

		public Tile GetNextTile()
		{
			return m_unusedTiles.Dequeue();
		}

		public void PlaceTile(Tile tile, Vector2 pos)
		{
			//TODO
		}

		public void GetPossiblePlacements(Tile tile)
		{
			foreach (Tile openSpace in m_openSpaceTiles)
			{
				//TODO
			}
		}
	}
}

